using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Text.Json;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Exel = Microsoft.Office.Interop.Excel;

using AddressBookUI;

namespace addressbook_test_data_generators
{
    class Program
    {
        //function doesn't return values but gets parameters, args- massive 
        //    static void Main(string[] args)
        //    {
        //        int count = Convert.ToInt32(args [0]);
        //        string filename = args[1];
        //        string format = args[2];

        //        List<GroupData> groups = new List<GroupData>();

        //        for (int i= 0; i < count; i++)
        //        {
        //            groups.Add(new GroupData(BaseTest.GenerateRandomString(10))
        //            {
        //                GroupHeader = BaseTest.GenerateRandomString(100),
        //                GroupFooter = BaseTest.GenerateRandomString(100),
        //            });
        //        }
        //        if (format == "exel")
        //        {

        //            writeGroupsToExelFile(groups, filename);
        //        }

        //        else
        //        {
        //            StreamWriter writer = new StreamWriter(filename);
        //            if (format == "csv")
        //            {
        //                writeGroupsToCvsFile(groups, writer);
        //            }
        //            else if (format == "xml")
        //            {
        //                writeGroupsToXmlFile(groups, writer);
        //            }
        //            else if (format == "json")
        //            {
        //                writeGroupsToJsonFile(groups, writer);
        //            }
        //            else
        //            {
        //                System.Console.Out.Write("Unrecognized format" + format);
        //            }

        //            writer.Close();
        //        }
        //    }

        //    private static void writeGroupsToExelFile(List<GroupData> groups, string filename)
        //    {
        //        // code to start exel
        //        Exel.Application app = new Exel.Application();
        //        app.Visible = true;
        //        Exel.Workbook wb = app.Workbooks.Add();
        //        Exel.Worksheet sheet = wb.ActiveSheet;
        //        sheet.Cells[1, 1] = "test";

        //        int row = 1;
        //        // code to write in data 
        //        foreach (GroupData group in groups)
        //        {
        //            //[stroka, stolbec]
        //            sheet.Cells[row, 1] = group.GroupName;
        //            sheet.Cells[row, 1] = group.GroupHeader;
        //            sheet.Cells[row, 1] = group.GroupFooter;
        //            row++;
        //        }
        //        //code to save result
        //        string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
        //        File.Delete(fullPath);
        //        wb.SaveAs(fullPath);

        //        wb.Close();
        //        app.Visible = false;
        //        app.Quit();
        //    }

        //    static void writeGroupsToCvsFile(List<GroupData> groups, StreamWriter writer)

        //    {
        //        foreach (GroupData group in groups)
        //        {
        //            writer.WriteLine(String.Format("${0},${1},${2},",
        //                group.GroupName, group.GroupHeader, group.GroupFooter));
        //        }
        //    }

        //    static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        //    {
        //        new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        //    }

        //    static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        //    { 
        //      writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));  
        //    }

        //}
        //string- type of maassive, args-- name of one variable
        static void Main(string[] args)
        {
            var contactType = args[0];
            int count = Convert.ToInt32(args[1]);
            string filename = args[2];
            string format = args[3];

            if (args[0] == "groups")
               
            {
                List<GroupData> groups = new List<GroupData>();

                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(BaseTest.GenerateRandomString(10))
                    {
                        GroupHeader = BaseTest.GenerateRandomString(100),
                        GroupFooter = BaseTest.GenerateRandomString(100),
                    });
                }
                if (format == "exel")
                {

                    writeGroupsToExelFile(groups, filename);
                }

                else
                {
                    StreamWriter writer = new StreamWriter(filename);
                    if (format == "csv")
                    {
                        writeGroupsToCvsFile(groups, writer);
                    }
                    else if (format == "xml")
                    {
                        writeGroupsToXmlFile(groups, writer);
                    }
                    else if (format == "json")
                    {
                        writeGroupsToJsonFile(groups, writer);
                    }
                    else
                    {
                        System.Console.Out.Write("Unrecognized format" + format);
                    }

                    writer.Close();
                }
            }

            else
            // contact type = contact
            {
                List<ContactData> contacts = new List<ContactData>();

                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactData(BaseTest.GenerateRandomString(10), BaseTest.GenerateRandomString(10))
                    {
                        Address = BaseTest.GenerateRandomString(100),
                        MobilePhone = BaseTest.GenerateRandomString(100),
                        Email = BaseTest.GenerateRandomString(100),
                    });
                } 
                StreamWriter writer = new StreamWriter(filename);
                
                if (format == "xml")
                {
                    writeContactsToXmlFile(contacts, writer);
                }
                else if (format == "json")
                
                    {
                        writeContactsToJsonFile(contacts, writer);
                    }

                    else
                    {
                        System.Console.Out.Write("Unrecognized format" + format);
                    }
                    writer.Close();
                }
            }
            static void writeGroupsToExelFile(List<GroupData> groups, string filename)
            {
                // code to start exel
                Exel.Application app = new Exel.Application();
                app.Visible = true;
                Exel.Workbook wb = app.Workbooks.Add();
                Exel.Worksheet sheet = wb.ActiveSheet;
                sheet.Cells[1, 1] = "test";

                int row = 1;
                // code to write in data 
                foreach (GroupData group in groups)
                {
                    //[stroka, stolbec]
                    sheet.Cells[row, 1] = group.GroupName;
                    sheet.Cells[row, 1] = group.GroupHeader;
                    sheet.Cells[row, 1] = group.GroupFooter;
                    row++;
                }
                //code to save result
                string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
                File.Delete(fullPath);
                wb.SaveAs(fullPath);

                wb.Close();
                app.Visible = false;
                app.Quit();
            }

            static void writeGroupsToCvsFile(List<GroupData> groups, StreamWriter writer)

            {
                foreach (GroupData group in groups)
                {
                    writer.WriteLine(String.Format("${0},${1},${2},",
                        group.GroupName, group.GroupHeader, group.GroupFooter));
                }
            }

            static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
            {
                new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
            }

            static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
            {
                writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
            }


            ///methods to  write in data into Contacts file
            static void writeContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
            {
                new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
            }

            static void writeContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
            {
                writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
            }
        }
    }

