using System;
using System.Collections.Generic;
using System.Text;

namespace ListViewXAML;
public class School {
    public string Name { get; set; }
    public string WebsiteURL { get; set; }
    public Color SchoolColor { get; set; }
    public Color School2ndColor { get; set; }
    public override String ToString() {
        return String.Format("{0} ({1})", Name, WebsiteURL);
    }
}
