using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Diagnostics;

namespace SymptomTracker;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        LoadSymptoms();
    }

    public void LoadSymptoms()
    {
        var all = DB.GetAllSymptoms();
        if (byDate.IsChecked) all = all.OrderBy(x => x.Datetime).ToList();
        else all = all.OrderByDescending(x => x.Strength).ToList();
        lv.ItemsSource = all;
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        Symptom template = new Symptom(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 00, 00), "", 5);
        EditItem editItem = new EditItem("Add", template);
        await Navigation.PushModalAsync(editItem);
        Symptom newSymptom = await editItem.ShowAsyncSymptom();
        if(template != newSymptom) DB.InsertSymptom(newSymptom);
        LoadSymptoms();
    }

    private void sort(object sender, CheckedChangedEventArgs e)
    {
        LoadSymptoms();
    }

    private async void lv_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        string method = await DisplayActionSheet("SelectedItem", "Back", null, "Modify Record", "Delete Record");
        if (method == "Delete Record")
        {
            bool result = await DisplayAlert("Warning", "Do you wish to delete this record?", "Yes", "No");
            if (e.SelectedItem is Symptom selected && result)
            {
                DB.DeleteSymptom(selected);
            }
        }
        else if (method == "Modify Record")
        {
            if (e.SelectedItem is Symptom selected)
            {
                EditItem editItem = new EditItem("Update", selected);
                await Navigation.PushModalAsync(editItem);
                Symptom newSymptom = await editItem.ShowAsyncSymptom();
                DB.DeleteSymptom(selected);
                DB.InsertSymptom(newSymptom);
            }
        }
        LoadSymptoms();
    }
}