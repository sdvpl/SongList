using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Office.Interop.Excel;

namespace SongList
{
    public partial class Form1 : Form
    {

        public Form1() => InitializeComponent();

        private void SearchButton(object sender, EventArgs e)
        {
            Search();
        }

        private void SearchEnterKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)

            {
                Search();
            }
        }

        private void Search()
        {
            TextInfo TInfo = new CultureInfo("en-US", false).TextInfo;
            String text = TInfo.ToTitleCase(ArtistSearchBox.Text);
            ArtistSearch(text);
            ShowAlbumSearch();
        }

        private void ArtistSearch(String ArtistName)
        {
            ArtstAlbumSearchListView.Items.Clear();
            ArtstAlbumSearchListView.ListViewItemSorter = null;
            if (String.IsNullOrEmpty(ArtistSearchBox.Text))
            {
                Console.WriteLine(ArtistSearchBox.Text + "null");
            }
            else
            {
                var Artistrequest = (HttpWebRequest)WebRequest.Create("https://musicbrainz.org/ws/2/artist/?query=" + ArtistName);
                Artistrequest.Method = "GET";
                Artistrequest.UserAgent = "DesktopApp1/1.1.1 ( sdvpl2011@gmail.com )";
                Artistrequest.Credentials = new NetworkCredential("sdvpl2011", "musicbrainz");
                var Artistresponse = (HttpWebResponse)Artistrequest.GetResponse();
                string ArtistID = "";
                string name = "";

                XmlReader reader = XmlReader.Create(Artistresponse.GetResponseStream());
                while (reader.Read())
                {
                        

                    if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "artist"))
                    {
                        ArtistID = reader.GetAttribute("id");
                        Console.WriteLine(value: ArtistID);
                        reader.ReadToDescendant("name");
                        name = reader.ReadElementContentAsString();
                        Console.WriteLine("Check Name = " + name);
                        if(name == ArtistName)
                        {
                            break;
                        }
                        //reader.Skip();
                        //reader.ReadToFollowing("name");
                        //break;
                        //.ReadElementContentAsString();
                        //XmlReader inner = reader.ReadSubtree();

                        //inner.ReadToDescendant("name");
                        //Console.WriteLine("Check Name = " + reader.ReadElementContentAsString());
                    }

                        //reader.ReadToFollowing("artist");
                        

                        

                }
                Artistresponse.Close();


                if (String.IsNullOrEmpty(ArtistID))
                {
                    Console.WriteLine("ArtistID is empty");
                    //AlbumSearch(ArtistID);
                }
                else
                {
                    Console.WriteLine("ArtisID is not empty");
                    AlbumSearch(ArtistID, name);
                }
            }

            this.ArtstAlbumSearchListView.ListViewItemSorter = new ListViewItemComparer(2);
            ArtstAlbumSearchListView.Sort();
            //listView1.Columns[2].Width = 0;
        }

        private void AlbumSearch(String ArtistID, String ArtistName)
        {
            //https://musicbrainz.org/ws/2/release?release-group=3d00fb45-f8ab-3436-a8e1-b4bfc4d66913
            //http://musicbrainz.org/ws/1/release/03e4ebe1-0a44-411c-8e19-78e0768603f8?type=xml&inc=tracks

            var Albumrequest = (HttpWebRequest)WebRequest.Create("https://musicbrainz.org/ws/2/release-group?artist=" + ArtistID);
            //var Albumrequest = (HttpWebRequest)WebRequest.Create("http://musicbrainz.org/ws/1/artist/" + ArtistID + "?type=xml&inc=sa-Official+release-events");

            Albumrequest.Method = "GET";
            Albumrequest.UserAgent = "DesktopApp1/1.1.1 ( sdvpl2011@gmail.com )";
            Albumrequest.Credentials = new NetworkCredential("sdvpl2011", "musicbrainz");
            var Albumresponse = (HttpWebResponse)Albumrequest.GetResponse();
            String Aname = ArtistName;
            String Albumname = "";
            String ReleaseDate = "";
            String AlbumID = "";
            ListViewItem listViewItemAlbum;

            XmlReader reader = XmlReader.Create(Albumresponse.GetResponseStream());
            while (reader.Read())
            {
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "release-group"))
                {
                    AlbumID = reader.GetAttribute("id");
                }
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "title"))
                {

                    Albumname = reader.ReadElementContentAsString();
                }

                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "first-release-date"))
                {
                    ReleaseDate = reader.ReadElementContentAsString();
                    string[] row1 = { Aname, Albumname, ReleaseDate };
                    listViewItemAlbum = new ListViewItem(row1);
                    listViewItemAlbum.Tag = AlbumID;
                    ArtstAlbumSearchListView.Items.Add(listViewItemAlbum);
                }
            }
            Albumresponse.Close();
        }

        private void ClearSelectionButton(object sender, EventArgs e)
        {
            ArtstAlbumSearchListView.Items.Clear();
            ArtstAlbumSearchListView.View = View.Details;
            AlbumTrackListView.Items.Clear();
            AlbumTrackListView.View = View.Details;
            SongListView.Items.Clear();
            SongListView.View = View.Details;
            ShowAlbumSearch();
        }

        private void AlbumSort(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
            this.ArtstAlbumSearchListView.ListViewItemSorter = new ListViewItemComparer(e.Column);
            ArtstAlbumSearchListView.Sort();
            string column_name = e.Column.ToString();
        }

        class ListViewItemComparer : IComparer
        {
            private int col;
            private SortOrder order;
            public ListViewItemComparer()
            {
                col = 0;
                order = SortOrder.Ascending;
            }
            public ListViewItemComparer(int column)
            {
                col = column;
            }

            public int Compare(object x, object y)
            {
                int returnVal;

                try
                {
                    System.DateTime firstDate =
                            DateTime.Parse(((ListViewItem)x).SubItems[col].Text);
                    System.DateTime secondDate =
                            DateTime.Parse(((ListViewItem)y).SubItems[col].Text);
                    returnVal = DateTime.Compare(firstDate, secondDate);
                }

                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine("System.ArgumentOutOfRangeException" + e.ToString());
                    returnVal = 0;
                    return returnVal;
                    throw;
                }
                catch
                {
                    returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text,
                                ((ListViewItem)y).SubItems[col].Text);
                }

                if (order == SortOrder.Descending)
                    returnVal *= -1;
                return returnVal;
            }
        }

        private void AlbumSelected(object sender, EventArgs e)
        {
            string artistname = "";
            string Albumname = "";
            string releasedate = "";
            string albumid = "";
            string tag = "";

            ShowTrackListSearch();

            InstructionLabel3.Text = "Click on a track name to add it to your song list.";

            this.AlbumTrackListView.Items.Clear();

            if (ArtstAlbumSearchListView.SelectedItems.Count != 0)
            {
                ListViewItem listitem = ArtstAlbumSearchListView.SelectedItems[0];
                artistname = listitem.SubItems[0].Text;
                Albumname = listitem.SubItems[1].Text;
                releasedate = listitem.SubItems[2].Text;
                tag = listitem.Tag.ToString();
                albumid = tag;
                RecordSearch(artistname, Albumname, releasedate, albumid);
            }
        }

        private void ReturnToSearchButtonClick(object sender, EventArgs e)
        {
            ShowAlbumSearch();
            SearchArtistButton.Enabled = true;
            ClearArtistButton.Enabled = true;
            ArtistSearchBox.Enabled = true;


        }

        private void RecordSearch(string artistname, string aname, string rdate, string aid)
        {
            //https://musicbrainz.org/ws/2/release?release-group=3d00fb45-f8ab-3436-a8e1-b4bfc4d66913

            var Trackrequest = (HttpWebRequest)WebRequest.Create("https://musicbrainz.org/ws/2/release?release-group=" + aid);

            Trackrequest.Method = "GET";
            Trackrequest.UserAgent = "DesktopApp1/1.1.1 ( sdvpl2011@gmail.com )";
            Trackrequest.Credentials = new NetworkCredential("sdvpl2011", "musicbrainz");
            var Trackresponse = (HttpWebResponse)Trackrequest.GetResponse();
            string artname = artistname;
            string Albumname = aname;
            string ReleaseDate = rdate;
            string AlbumID = aid;
            string releaseid = "";
            string title = "";

            XmlReader reader = XmlReader.Create(Trackresponse.GetResponseStream());
            while (reader.Read())
            {
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "release"))
                {
                    releaseid = reader.GetAttribute("id");
                    //Console.WriteLine("releaseid = " + releaseid);
                }
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "title"))
                {
                    title = reader.ReadElementContentAsString();
                    //Console.WriteLine("title = " + title);
                    //Console.WriteLine("Albumname = " + Albumname);
                }
                if (releaseid != null && title == Albumname)
                {
                    //Console.WriteLine("Realease Id = " + releaseid);
                    TrackSearch(artname, Albumname, ReleaseDate, releaseid);
                    break;
                    
                }
            }
            Trackresponse.Close();
        }

        private void TrackSearch(string artname, string aname, string rdate, string aid)
        {
            var Trackrequest = (HttpWebRequest)WebRequest.Create("http://musicbrainz.org/ws/1/release/" + aid + "?type=xml&inc=tracks");

            Trackrequest.Method = "GET";
            Trackrequest.UserAgent = "DesktopApp1/1.1.1 ( sdvpl2011@gmail.com )";
            Trackrequest.Credentials = new NetworkCredential("sdvpl2011", "musicbrainz");
            var Trackresponse = (HttpWebResponse)Trackrequest.GetResponse();
            string artistname = artname;
            string Albumname = aname;
            string ReleaseDate = rdate;
            string AlbumID = aid;
            string trackname;
            List<ListViewItem> myItems = new List<ListViewItem>();
            ListViewItem listViewItem; //= new ListViewItem(row);

            XmlReader reader = XmlReader.Create(Trackresponse.GetResponseStream());

            while (reader.Read())
            {
                var elementName = string.Empty;
                if (reader.NodeType == XmlNodeType.Element)
                {
                    elementName = reader.Name;
                    switch (elementName)
                    {
                        case "track-list":
                            {
                                var subReader = reader.ReadSubtree();
                                while (subReader.ReadToFollowing("track"))
                                {
                                    if (subReader.ReadToFollowing("title"))
                                    {
                                        trackname = reader.ReadElementContentAsString();
                                        string[] row = { artistname, Albumname, trackname };
                                        listViewItem = new ListViewItem(row);
                                        AlbumTrackListView.Items.Add(listViewItem);
                                        //myItems.Add(listViewItem);
                                        //Console.WriteLine("myItems count:" + myItems.Count);
                                    }
                                }
                                break;
                            }
                    }
                }
            }
            Trackresponse.Close();
        }

        private void SongSelection_click(object sender, EventArgs e)
        {

            if (AlbumTrackListView.SelectedItems.Count != 0)
            {
                AddToSongList();
            }
        }

        public void AddToSongList()
        {
            string artistname = "";
            string albumname = "";
            string trackname = "";

            if (AlbumTrackListView.SelectedItems.Count != 0)
            {
                ListViewItem listitem = AlbumTrackListView.SelectedItems[0];
                artistname = listitem.SubItems[0].Text;
                albumname = listitem.SubItems[1].Text;
                trackname = listitem.SubItems[2].Text;

                DialogResult dialogResult = MessageBox.Show("Would you like to add " + trackname + " to your song list?", "Remove Song", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string[] row1 = { artistname, albumname, trackname };
                    ListViewItem listvi = new ListViewItem(row1);
                    SongListView.Items.Add(listvi);
                }
                else if (dialogResult == DialogResult.No)
                {
                    //Console.WriteLine("No");
                }
                

            }
        }

        private void ShowAlbumSearch(object sender, EventArgs e)
        {
            ShowAlbumSearch();

        }

        private void ShowAlbumSearch()
        {
            ArtstAlbumSearchListView.Show();
            AlbumTrackListView.Hide();
            SongListView.Hide();
            InstructionLabel3.Text = "Click on an album name to display Track List.";
        }

        private void ShowTrackListSearch(object sender, EventArgs e)
        {
            this.ShowTrackListSearch();
        }

        private void ShowTrackListSearch()
        {
            AlbumTrackListView.Show();
            ArtstAlbumSearchListView.Hide();
            SongListView.Hide();
        }

        private void ViewSongListButton_Click(object sender, EventArgs e)
        {
            AlbumTrackListView.Hide();
            ArtstAlbumSearchListView.Hide();
            SongListView.Show();
            InstructionLabel3.Text = "Click on an track name to remove it from the song list.";
        }

        private void ViewTrackListButton_Click(object sender, EventArgs e)
        {
            AlbumTrackListView.Show();
            ArtstAlbumSearchListView.Hide();
            SongListView.Hide();
            InstructionLabel3.Text = "Click on a track name to add it to your song list.";
        }

        private void ExportToExcel(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xls", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Add(XlSheetType.xlWorksheet);
                    Worksheet ws = (Worksheet)app.ActiveSheet;
                    app.Visible = false;

                    ws.Cells[1, 1] = "Artist/Band";
                    ws.Cells[1, 2] = "Album Name";
                    ws.Cells[1, 3] = "Track Name";

                    int i = 1;
                    int i2 = 2;
                    foreach (ListViewItem lvi in SongListView.Items)
                    {
                        i = 1;
                        foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
                        {
                            ws.Cells[i2, i] = lvs.Text;
                            i++;
                        }
                        i2++;
                    }
                    wb.SaveAs(sfd.FileName, XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, true, false, XlSaveAsAccessMode.xlNoChange, XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);
                    app.Quit();
                    MessageBox.Show("Your data has been successfully exported", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void DeleteFromTrackList(object sender, EventArgs e)
        {
            string artistname = "";
            string albumname = "";
            string trackname = "";

            if (SongListView.SelectedItems.Count != 0)
            {
                ListViewItem listitem = SongListView.SelectedItems[0];
                artistname = listitem.SubItems[0].Text;
                albumname = listitem.SubItems[1].Text;
                trackname = listitem.SubItems[2].Text;

                DialogResult dialogResult = MessageBox.Show("Would you like to remove "+ trackname + " from your song list?", "Remove Song", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SongListView.SelectedItems[0].Remove();
                }
                else if (dialogResult == DialogResult.No)
                {
                    //Console.WriteLine("No");
                }
            }
        }
    }
}
