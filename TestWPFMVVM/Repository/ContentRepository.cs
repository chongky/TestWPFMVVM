using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TestWPFMVVM.Models;

namespace TestWPFMVVM.Repository
{
    public class ContentRepository
    {
        public List<Content> Select()
        {
            List<Content> contents = new List<Content>();

            Content content = new Content() { Name = "OS (C:)", ContentType = "Drive" };
            Content subContent;

            // C:
            content.Children.Add(new Content() { Name = "apps", ContentType = "Folder" });
            content.Children.Add(new Content() { Name = "dell", ContentType = "Folder" });
            content.Children.Add(new Content() { Name = "Drivers", ContentType = "Folder" });
            content.Children.Add(new Content() { Name="New Document.txt", ContentType = "File" });

            // C:\apps
            subContent = content.Children[0];
            subContent.Children.Add(new Content() { Name = "DDPA2239", ContentType = "Folder" });

            // C:\apps\DDPA2239
            subContent = subContent.Children[0];
            subContent.Children.Add(new Content() { Name = "config.xml", ContentType = "File" });

            // C:\dell
            subContent = content.Children[1];
            subContent.Children.Add(new Content() { Name = "DCSUStart.bat", ContentType = "File" });

            // C:\Drivers
            subContent = content.Children[2];
            subContent.Children.Add(new Content() { Name="audio", ContentType="Folder" });
            subContent.Children.Add(new Content() { Name="input",ContentType="Folder" });

            // C:\Drivers\audio
            subContent = subContent.Children[0];
            subContent.Children.Add(new Content() { Name = "36sec.mp3", ContentType = "File" });
            subContent.Children.Add(new Content() { Name = "navigation.xml", ContentType = "File" });

            // C:\Drivers\input
            subContent = content.Children[2].Children[1];
            subContent.Children.Add(new Content() { Name = "Data", ContentType = "Folder" });
            subContent.Children.Add(new Content() { Name = "ApInst.dll", ContentType = "File" });
            subContent.Children.Add(new Content() { Name = "Apoint.exe", ContentType = "File" });

            // C:\Drivers\input\Data
            subContent = subContent.Children[0];
            subContent.Children.Add(new Content() { Name = "CirSrD.cur", ContentType = "File" });
            subContent.Children.Add(new Content() { Name = "CirSrL.cur", ContentType = "File" });
            subContent.Children.Add(new Content() { Name = "CirSrU.cur", ContentType = "File" });
            subContent.Children.Add(new Content() { Name = "CirSrR.cur", ContentType = "File" });

            // add a file to c:\

            contents.Add(content);

            return contents;
        }
    }
}
