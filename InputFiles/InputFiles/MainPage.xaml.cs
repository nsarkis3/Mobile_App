using Microsoft.Maui.Storage;
using System.Reflection;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace InputFiles;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		picker.SelectedIndex = 0;
	}
	// Within MS VS, the file data.txt has the property "Embedded Resource"
	// The file is readonly and is not editable.
	private static string GetFullNameOfEmbeddedResource(string baseName) {
		string namespaceName = "InputFiles";
		string fullFileName = namespaceName + "." + baseName;
		return fullFileName;
	}
	private static string GetFullNameOfDataFile(string baseName) {
		//string directory = FileSystem.Current.CacheDirectory;
		string directory = FileSystem.Current.AppDataDirectory;
		string fullName = Path.Combine(directory, baseName);
		return fullName;
	}
	private static Stream GetInputStreamForEmbeddedResource(string baseName) {
		var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MainPage)).Assembly;
		string fullFileName = GetFullNameOfEmbeddedResource(baseName);
		return assembly.GetManifestResourceStream(fullFileName);
	}
	private static string GetContentsOfEmbeddedResource(string baseName) {
		Stream stream = GetInputStreamForEmbeddedResource(baseName);
		StreamReader reader = new StreamReader(stream);

		string text = reader.ReadToEnd();
		stream.Close();

		return text;
	}
	private static string GetContentsOfDataFile(string baseName) {
		string fullFileName = GetFullNameOfDataFile(baseName);
		string text = "";
		try {
			using (var dictReader = new System.IO.StreamReader(fullFileName)) {
				text = dictReader.ReadToEnd();
			}
		}
		catch (Exception e) {
			return null;
		}
		return text;
	}
	private void SaveContentsOfDataFile(string baseFileName, string contents) {
		string fullFileName = GetFullNameOfDataFile(baseFileName);
		StreamWriter writer = new StreamWriter(fullFileName);
		writer.Write(contents);
		writer.Close();
	}
	private void LoadClicked(object sender, EventArgs e) {
		string fileType = picker.SelectedItem as string;
		string contents = "n/a";
		switch (fileType) {
			case "Poem":	
				contents = GetContentsOfDataFile("poem.txt");
				break;
			case "Todo list":
				contents = GetContentsOfDataFile("todo.txt");
				break;
			default:
				contents = GetContentsOfEmbeddedResource("AppStuff.txt");
				break;
		}
		editor.Text = contents;
	}

	private void SaveClicked(object sender, EventArgs e) {
		string fileType = picker.SelectedItem as string;
		switch (fileType) {
			case "Poem":
				SaveContentsOfDataFile("poem.txt", editor.Text);
				break;
			case "Todo list":
				SaveContentsOfDataFile("todo.txt", editor.Text);
				break;
			default:
				// Can't update an embedded resource
				break;
		}
	}

	private void ExitClicked(object sender, EventArgs e) {
		Environment.Exit(0);
	}
}

