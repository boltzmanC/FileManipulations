using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.Data;
using FluentFTP;

namespace FileManipulations
{
    public class MichelinAnnualTester
    {


        // Michelin MSPN file process. outputs 4 separate files.

        //static public void MichelinXLSXToPipeTXT(string filepath, string newfilepath)
        //{
        //    //Console.WriteLine("Enter XLSX file.");
        //    //string filepath = GetAFile();

        //    DataSet result = null;

        //    using (var stream = File.Open(filepath, FileMode.Open, FileAccess.Read))
        //    {

        //        // Auto-detect format, supports:
        //        //  - Binary Excel files (2.0-2003 format; *.xls)
        //        //  - OpenXml Excel files (2007 format; *.xlsx)
        //        using (var reader = ExcelReaderFactory.CreateReader(stream))
        //        {
        //            result = reader.AsDataSet(new ExcelDataSetConfiguration() { ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true } });
        //        }
        //    }

        //    //first sheet. can itterate to accompdate for each sheet in the excel file.
        //    DataTable firstsheet = result.Tables[0]; //To txt file Tables[0] = first sheet.

        //    //to csv (copied code: http://dotnetmentors.com/adonet/convert-datatable-to-csv-or-list-or-json-string.aspx)
        //    StreamWriter sw = new StreamWriter(newfilepath, false);
        //    //headers  
        //    for (int i = 0; i < firstsheet.Columns.Count; i++)
        //    {
        //        sw.Write(firstsheet.Columns[i]);
        //        if (i < firstsheet.Columns.Count - 1)
        //        {
        //            sw.Write("|"); // comma
        //        }
        //    }
        //    sw.Write(sw.NewLine);
        //    foreach (DataRow dr in firstsheet.Rows)
        //    {
        //        for (int i = 0; i < firstsheet.Columns.Count; i++)
        //        {
        //            if (!Convert.IsDBNull(dr[i]))
        //            {
        //                string value = dr[i].ToString();
        //                //if (value.Contains(','))
        //                //{
        //                //   value = String.Format("\"{0}\"", value);
        //                //   sw.Write(value);
        //                //}
        //                //else
        //                //{
        //                //   sw.Write(dr[i].ToString());
        //                //}

        //                // wrapp all values....
        //                //value = String.Format("\"{0}\"", value);
        //                //sw.Write(value);

        //                //just write the value... no qualifiers.
        //                sw.Write(value);

        //            }
        //            if (i < firstsheet.Columns.Count - 1)
        //            {
        //                sw.Write("|"); //commma
        //            }
        //        }
        //        sw.Write(sw.NewLine);
        //    }
        //    sw.Close();

        //}

        static public void ACTIVEMSPNFormattedFiles() // add catch for missing columns??? 
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine();
            Console.WriteLine("This is to create the 5 MSPN related files needed for Michelin.");
            Console.WriteLine("Please REMOVE ALL SPACES in the file name and file path.");
            Console.WriteLine("!!!!Please DELETE ALL  \"  in the MSPN file before PROCEEDING!!!!");
            Console.WriteLine();
            Console.WriteLine("Please save the provided .xls or .xlsx file as .CSV");
            Console.ResetColor();
            Console.WriteLine("Click and drag the file here.");
            //Create folder for the files.

            string folderpath = GetDesktopDirectory() + @"\MichelinMSPNFiles";

            if (!Directory.Exists(folderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(folderpath);
            }

            //Get the file.
            string filepath = GetAFile();
            string newfilepath = folderpath + "\\" + GetFileNameWithoutExtension(filepath) + "_notouchy.txt"; //.csv

            Console.WriteLine("Michelin magic happening... please standbye...");


            // Uncomment to -> Convert from XLSX or XLS to CSV. Outputs to new Michelin folder
            //MichelinXLSXToPipeTXT(filepath, newfilepath);

            //    Read File format columns. Resave.
            string formattedactivemspn = folderpath + "\\" + GetFileNameWithoutExtension(filepath) + "_ColumnValuesFormatted.txt";


            // if not using XLSX -> CSV converter uncomment this code.
            //
            // add option to use just a csv file instead of starting with the xls.
            //


            // all new files delimiter.
            char mspndel = '|';  //Manually change to PIPE delimited txt file.

            using (StreamReader activemspnfile = new StreamReader(newfilepath))
            {
                //Header
                string header = activemspnfile.ReadLine();
                string[] columnlist = header.Split(mspndel);

                //Find Columns. - > Leading zeroes format - String.Format("{0:000000}", 6); -> 000006
                int mspnid = ColumnIndex(header, mspndel, "MSPN ID");                      //MSPN
                int brandid = ColumnIndex(header, mspndel, "Code Marque ID");              //BRAND
                int productlineid = ColumnIndex(header, mspndel, "Product Line DESC");     //PRODUCTLINE
                int groupcategorynames = ColumnIndex(header, mspndel, "Groupe Category");  //DSS_CATEGORY
                int customerspecificflag = ColumnIndex(header, mspndel, "Customer Specific Flag");

                List<string> grpcategoryvalues = new List<string> { "ENTRY (S,T)", "V", "H", "Z", "REC/COM", "WINTER" }; //Group Category (case sensative)

                //Create Formatted verision of the file.
                using (StreamWriter formatedwritefile = new StreamWriter(formattedactivemspn))
                {
                    formatedwritefile.WriteLine(header);

                    //Format Columns.
                    string line = string.Empty;
                    while ((line = activemspnfile.ReadLine()) != null)
                    {
                        string[] splitline = line.Split(mspndel);

                        //Leading 0 formats.
                        splitline[mspnid] = String.Format("{0:00000}", splitline[mspnid]);
                        splitline[brandid] = String.Format("{0:000}", splitline[brandid]);
                        splitline[productlineid] = String.Format("{0:0000000}", splitline[productlineid]);

                        //Group Category Formats.
                        if (!grpcategoryvalues.Contains(splitline[groupcategorynames].Trim().ToUpper().Replace("\"", string.Empty)))
                        {
                            Console.Write("Group Category column error found, current value - {0}, enter new value: ", splitline[groupcategorynames]);
                            string valuefix = Console.ReadLine().Trim().ToUpper().Replace("\"", string.Empty);

                            splitline[groupcategorynames] = valuefix;
                        }

                        //Customer Specific Flag - formats.
                        if (string.IsNullOrWhiteSpace(splitline[customerspecificflag]))
                        {
                            splitline[customerspecificflag] = "N/A";
                        }

                        //join the formatted strings. write to file.
                        string newline = string.Join(mspndel.ToString(), splitline);
                        formatedwritefile.WriteLine(newline);
                    }
                }
            }

            // Active_MSPN file.
            string activemspnfilereload = folderpath + "\\ActiveMSPNS.txt";

            using (StreamReader readformatedmspns = new StreamReader(formattedactivemspn))
            {
                //header.
                string header = readformatedmspns.ReadLine();

                //E1 Table columns.
                string[] tablecolumns = { "TIRE_SIZE", "DSS_CATEGORY", "MSPN", "PRODUCTLINE", "BRAND", "COMP_FLAG", "DESCRIPTION", "PMET" };
                string[] filecolumnstochange = { "Tire Size", "Groupe Category", "MSPN ID", "Product Line DESC", "Code Marque DESC", "Comp Flag", "GLPC DESC", "P Met Ind" };

                List<int> columnindexes = new List<int> { };

                //Get Column indexes.
                foreach (var s in filecolumnstochange)
                {
                    columnindexes.Add(ColumnIndex(header, mspndel, s));
                }

                using (StreamWriter writemspn = new StreamWriter(activemspnfilereload))
                {
                    //write header
                    string newheader = string.Join(mspndel.ToString(), tablecolumns);
                    writemspn.WriteLine(newheader);

                    //read rest of file, write new lines.
                    string line = string.Empty;
                    while ((line = readformatedmspns.ReadLine()) != null)
                    {
                        List<string> linebuilder = new List<string> { };
                        string[] splitline = line.Split(mspndel);

                        foreach (var i in columnindexes)
                        {
                            linebuilder.Add(splitline[i]);
                        }

                        //combine list and add to string.
                        string newline = string.Join(mspndel.ToString(), linebuilder);

                        //write string to new file.
                        writemspn.WriteLine(newline);
                    }

                }
            }


            // Active_MSPN1 file.
            string activemspnfile1reload = folderpath + "\\ActiveMSPNS1.txt";

            using (StreamReader readformatedmspns = new StreamReader(formattedactivemspn))
            {
                //header.
                string header = readformatedmspns.ReadLine();

                //Column filter.
                int filtercolumn = ColumnIndex(header, mspndel, "Code Marque DESC"); //    Filter the Code Marque DESC column for BFGoodrich, Michelin, Uniroyal Brands. write those rows to new file.
                List<string> filteroptions = new List<string> { "BFGOODRICH", "MICHELIN", "UNIROYAL" };


                using (StreamWriter writemspn1 = new StreamWriter(activemspnfile1reload))
                {
                    //Write Header.
                    writemspn1.WriteLine(header);

                    //read rest of file.
                    string line = string.Empty;
                    while ((line = readformatedmspns.ReadLine()) != null)
                    {
                        string[] splitline = line.Split(mspndel);

                        if (filteroptions.Contains(splitline[filtercolumn].ToUpper().Trim()))
                        {
                            writemspn1.WriteLine(line);
                        }

                    }
                }
            }


            //Group_Category_Lookup - from mspns1 file.
            // https://confluence.nexgen.neustar.biz/pages/viewpage.action?pageId=128004469
            Console.WriteLine();
            Console.WriteLine("Group_Category_Lookup is still unchanged - output generated anyway...");

            string groupcategorylookupfile = folderpath + "\\GroupCategoryLookupNOTUSED.txt";

            using (StreamReader readactivemspn1 = new StreamReader(activemspnfile1reload))
            {
                //header
                string header = readactivemspn1.ReadLine();

                // Customer Specific Flag column.
                string groupcategorycolumn = "Groupe Category";

                //find column.
                int groupcategoryindex = ColumnIndex(header, mspndel, groupcategorycolumn);

                using (StreamWriter writegroupcategory = new StreamWriter(groupcategorylookupfile))
                {
                    //new columns
                    string[] newcolumns = { "LABEL", "VALUE" };

                    //list to store uniqe flags.
                    List<string> uniquegroupcategory = new List<string> { };

                    //write header. 
                    writegroupcategory.WriteLine(string.Join(mspndel.ToString(), newcolumns));

                    string line = string.Empty;
                    while ((line = readactivemspn1.ReadLine()) != null)
                    {
                        string[] splitline = line.Split(mspndel);

                        if (!uniquegroupcategory.Contains(splitline[groupcategoryindex]))
                        {
                            uniquegroupcategory.Add(splitline[groupcategoryindex]);
                        }
                    }

                    string originalvalue = "ENTRY (S,T)";
                    string changevalue = "ENTRY (S T)";

                    foreach (var s in uniquegroupcategory)
                    {
                        if (s == originalvalue)
                        {
                            writegroupcategory.WriteLine(s + mspndel + changevalue);
                        }
                        else
                        {
                            writegroupcategory.WriteLine(s + mspndel + s);
                        }
                    }
                }
            }


            // PRODUCTLINES_LOOKUP file - From the Active_MSPNS1 file.

            string productlineslookup = folderpath + "\\ProductLines.txt";

            using (StreamReader readactivemspns1 = new StreamReader(activemspnfile1reload))
            {
                //list to hold the unique ids from the product ID column.
                List<string> productids = new List<string> { };
                //header.
                string header = readactivemspns1.ReadLine();

                string[] filecolumnstochange = { "Product Line ID", "Groupe Category", "Code Marque ID", "Product Line DESC" };
                //string productlinedesc = "Product Line DESC";
                string[] tablecolumns = { "PRODUCT_ID", "RT_GRP_CAT", "RT_BRAND", "PRODUCTLINEDESC" };
                //create new column by combining 'Product Line ID' + "-" + 'Product Line Desc' -> 'PRODUCTLINEDESC'

                //Get Column indexes.
                List<int> columnindexes = new List<int> { };
                foreach (var s in filecolumnstochange)
                {
                    columnindexes.Add(ColumnIndex(header, mspndel, s));
                }

                using (StreamWriter writeproductlines = new StreamWriter(productlineslookup))
                {
                    //write header.
                    string newheader = string.Join(mspndel.ToString(), tablecolumns);
                    writeproductlines.WriteLine(newheader);

                    //read rest of file.
                    string line = string.Empty;
                    while ((line = readactivemspns1.ReadLine()) != null)
                    {
                        List<string> linebuilder = new List<string> { };
                        string[] splitline = line.Split(mspndel);

                        string productidgroups = splitline[columnindexes[0]] + "_" + splitline[columnindexes[1]]; //Product_ID and Group Category together into new ID -> ProductIDGroups

                        //    select unique ProductIDGroups - this is what eric said to do....
                        if (!productids.Contains(productidgroups))
                        {
                            //add found value to list.
                            productids.Add(productidgroups);

                            //get column data
                            foreach (var i in columnindexes)
                            {
                                if (splitline[i].ToUpper().Trim() == "ENTRY (S,T)") // ENTRY(S,T) changed to ENTRY(S T)
                                {
                                    linebuilder.Add(splitline[i].Replace(',', ' '));
                                }
                                else
                                {
                                    linebuilder.Add(splitline[i]);
                                }
                            }

                            //format 'Product Line ID-DESC'
                            string[] lineformatting = linebuilder.ToArray();
                            // change last value.
                            lineformatting[lineformatting.Length - 1] = lineformatting[0] + "-" + lineformatting[lineformatting.Length - 1];

                            string newline = string.Join(mspndel.ToString(), lineformatting);
                            writeproductlines.WriteLine(newline);
                        }
                    }
                }
            }


            //KEYPRODUCTLINES file - from ActiveMSPNS1
            string keyproductlines = folderpath + "\\KEYPRODUCTLINES.txt";

            using (StreamReader readactivemspns1 = new StreamReader(activemspnfile1reload))
            {
                //list to hold the unique ids from the product ID column.
                List<string> productids = new List<string> { };
                //header.
                string header = readactivemspns1.ReadLine();

                string[] filecolumnstochange = { "Product Line ID", "Product Line DESC" };
                //string productlinedesc = "Product Line DESC";
                string[] tablecolumns = { "PRODUCT_ID", "PRODUCTLINEDESC" };
                //create new column by combining 'Product Line ID' + "-" + 'Product Line Desc' -> 'PRODUCTLINEDESC'

                //Get Column indexes.
                List<int> columnindexes = new List<int> { };
                foreach (var s in filecolumnstochange)
                {
                    columnindexes.Add(ColumnIndex(header, mspndel, s));
                }

                using (StreamWriter writekeyproductlines = new StreamWriter(keyproductlines))
                {
                    //write header.
                    string newheader = string.Join(mspndel.ToString(), tablecolumns);
                    writekeyproductlines.WriteLine(newheader);

                    //read rest of file.
                    string line = string.Empty;
                    while ((line = readactivemspns1.ReadLine()) != null)
                    {
                        List<string> linebuilder = new List<string> { };
                        string[] splitline = line.Split(mspndel);

                        //    select unique Product Line IDs - this is what eric said to do....
                        if (!productids.Contains(splitline[columnindexes[0]]))
                        {
                            //add found value to list.
                            productids.Add(splitline[columnindexes[0]]);

                            //get column data
                            foreach (var i in columnindexes)
                            {
                                linebuilder.Add(splitline[i]);
                            }

                            string[] buildnewline = linebuilder.ToArray();

                            string newline = string.Join(mspndel.ToString(), buildnewline);
                            writekeyproductlines.WriteLine(newline);
                        }
                    }
                }
            }


            // CUSTOMER_SPECIFIC_FLAG_LOOKUP file - from ActiveMSPNS1 file.
            string customerspecificfile = folderpath + "\\CustomerSpecificFlagLookup.txt";


            using (StreamReader readactivemspn1 = new StreamReader(activemspnfile1reload))
            {
                //header
                string header = readactivemspn1.ReadLine();

                // Customer Specific Flag column.
                string custromerflagcolumn = "Customer Specific Flag";

                //find column.
                int flagcolumnindex = ColumnIndex(header, mspndel, custromerflagcolumn);

                using (StreamWriter customerflagfile = new StreamWriter(customerspecificfile))
                {
                    //new columns
                    string[] newcolumns = { "LABEL", "VALUE" };

                    //list to store uniqe flags.
                    List<string> uniqueflags = new List<string> { };

                    //write header. 
                    customerflagfile.WriteLine(string.Join(mspndel.ToString(), newcolumns));

                    string line = string.Empty;
                    while ((line = readactivemspn1.ReadLine()) != null)
                    {
                        string[] splitline = line.Split(mspndel);

                        if (!uniqueflags.Contains(splitline[flagcolumnindex]))
                        {
                            uniqueflags.Add(splitline[flagcolumnindex]);
                        }
                    }

                    foreach (var s in uniqueflags)
                    {
                        //make '2' columns.
                        string newline = s + mspndel + s;

                        //writeline.
                        customerflagfile.WriteLine(newline);
                    }

                    //Add last ALL rows.
                    customerflagfile.WriteLine("ALL" + mspndel + "ALL");
                }
            }

            //What's been done....
            Console.WriteLine();
            Console.WriteLine("Done!");
            Console.WriteLine();
            Console.WriteLine("You should see a new folder on your Desktop Labeled, \"MichelinMSPNFiles\" with the following PIPE Delimited files: ");
            Console.WriteLine();

            string[] filearray = Directory.GetFiles(folderpath);
            foreach (var f in filearray)
            {
                Console.WriteLine(GetFileNameWithoutExtension(f) + ".txt");
            }
            Console.WriteLine();
        }



        //Michelin Polk Files
        //
        // used for annual updates.
        //Reads polk_zip file(90MM records, break into 8 parts) outputs #of original files x2 files and 3 condensed files.
        // polk code + vehicle counts file, state vehicle counts file, zip code vehicle coutns file.
        static public void MichelinPOLKReaderMultiTask()
        {
            // create directory for splitfiles.
            string splitfilefolderpath = GetDesktopDirectory() + @"\michelin_uspolk_counts\splitfiles";
            string zipfilefolderpath = GetDesktopDirectory() + @"\michelin_uspolk_counts\zipcounts";
            string polkfilefolderpath = GetDesktopDirectory() + @"\michelin_uspolk_counts\polkcounts";

            if (!Directory.Exists(splitfilefolderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(splitfilefolderpath);
            }

            if (!Directory.Exists(polkfilefolderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(polkfilefolderpath);
            }

            if (!Directory.Exists(zipfilefolderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(zipfilefolderpath);
            }

            // get source file.
            Console.WriteLine("-Enter Polk Zip file-");
            Console.Write("File: ");
            var inFile = new FileInfo(Console.ReadLine());
            //var polkziplistfile = Console.ReadLine();
            char deli = GetDelimiter();
            char txtq = '"';
            Console.WriteLine();

            //splitfile code. (code copies from BreakOneFileIntoMany)
            Int64 sourceRecordCount, iRecordCount, NoOutputFiles;

            Console.Write("Source Record Count (Enter nothing for auto count): ");

            if (Int64.TryParse(Console.ReadLine(), out iRecordCount))
                sourceRecordCount = iRecordCount;
            else
                sourceRecordCount = File.ReadLines(inFile.FullName).LongCount();

            Console.Write("No. of Output Files: ");
            NoOutputFiles = Int64.Parse(Console.ReadLine());

            Int64 linesWritten;
            double maxBreakoutRecordsPerFile = Math.Ceiling((double)sourceRecordCount / (double)NoOutputFiles);
            string readLine;

            Console.WriteLine("Spliting file...");

            using (var reader = new StreamReader(inFile.OpenRead()))
            {
                string header = reader.ReadLine();

                for (int i = 1; i <= NoOutputFiles; i++)
                {
                    using (var writer = new StreamWriter(splitfilefolderpath + "\\" + (inFile.Name.Replace(inFile.Extension, "").ToString() + "_split_" + i + inFile.Extension.ToString())))
                    {
                        writer.WriteLine(header);
                        linesWritten = 0;

                        while (linesWritten < maxBreakoutRecordsPerFile && (readLine = reader.ReadLine()) != null)
                        {
                            writer.WriteLine(readLine);
                            linesWritten++;
                        }
                    }
                }
            }

            // read splitfiles.
            //Console.WriteLine("-Drag and Drop Michelin Zip Data Files Folder here-");
            //Console.Write("Folder: ");
            //string zipdatadirectory = Console.ReadLine();
            string[] michelinzipdatafilepaths = Directory.GetFiles(@splitfilefolderpath);

            Console.WriteLine("-Enter State file-");
            string statefile = GetAFile();
            char statedeli = GetDelimiter();
            Console.WriteLine();

            Dictionary<string, HashSet<string>> statezipdictionary = new Dictionary<string, HashSet<string>>();

            using (StreamReader statezipfile = new StreamReader(statefile))
            {
                string header = statezipfile.ReadLine();

                string line = string.Empty;
                while ((line = statezipfile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, statedeli, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(statedeli));
                    }

                    string[] splitline = splitlinebuilder.ToArray();
                    string statecode = splitline[1].Replace(txtq.ToString(), "");
                    if (string.IsNullOrWhiteSpace(statecode))
                    {
                        statecode = "blank"; //accounts for states or provinces that do not appear in the state/province lookup files
                    }

                    string statename = splitline[2].Replace(txtq.ToString(), "");
                    string zip = splitline[0].Replace(txtq.ToString(), "");

                    if (!statezipdictionary.ContainsKey(statecode))
                    {
                        HashSet<string> temphash = new HashSet<string>();
                        temphash.Add(zip);
                        statezipdictionary.Add(statecode, temphash);
                    }
                    else
                    {
                        statezipdictionary[statecode].Add(zip);
                    }

                }
            }

            List<Task> tasklist = new List<Task>(); //using a task array and a file array was not working.
            try
            {
                foreach (var file in michelinzipdatafilepaths)
                {
                    var task = new Task(async () =>
                    {
                        string returned = await (MichelinPOLKZipDataReader(file, deli, txtq, statezipdictionary));
                        Console.WriteLine(returned);

                    });

                    tasklist.Add(task);
                    task.Start();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            try
            {
                Task.WaitAll(tasklist.ToArray());
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            //produces two files with total counts for polkkeys and zipcodes
            MichelinPOLKCountsFileCondenser(polkfilefolderpath, deli);
            MichelinPOLKZipCountsFileCondenser(zipfilefolderpath, deli); //by zip code file and by state code file.

        }

        static public Task<string> MichelinPOLKZipDataReader(string file1, char deli1, char txtq, Dictionary<string, HashSet<string>> statelookup)
        {
            string zipfilefolderpath = GetDesktopDirectory() + @"\michelin_uspolk_counts\zipcounts";
            string polkfilefolderpath = GetDesktopDirectory() + @"\michelin_uspolk_counts\polkcounts";

            string zipcountsfile = zipfilefolderpath + "\\" + GetFileNameWithoutExtension(file1) + "zip_counts.txt"; // list of zips, appended with counts
            string polkcountsfile = polkfilefolderpath + "\\" + GetFileNameWithoutExtension(file1) + "polk_counts.txt";

            Dictionary<string, int> ziplist = new Dictionary<string, int>();
            Dictionary<string, int> polkkeysums = new Dictionary<string, int>();

            int rowcount = 0;

            using (StreamReader readfile = new StreamReader(file1))
            {
                // read and save header.
                string header = readfile.ReadLine();

                string line = string.Empty;
                while ((line = readfile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, deli1, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(deli1));
                    }

                    string[] splitline = splitlinebuilder.ToArray();
                    string zip = splitline[0].Replace(txtq.ToString(), "");
                    string polk = splitline[1].Replace(txtq.ToString(), "");
                    int vehiclecount = Int32.Parse(splitline[2].Replace(txtq.ToString(), ""));

                    // ADD check for polk + zip combo. using a list made the process run for EVER!!!!! use a dict instead, or hashset.

                    if (!ziplist.ContainsKey(zip))
                    {
                        ziplist.Add(zip, vehiclecount);
                    }
                    else
                    {
                        ziplist[zip] += vehiclecount;
                    }


                    if (!polkkeysums.ContainsKey(polk))
                    {
                        polkkeysums.Add(polk, vehiclecount);
                    }
                    else
                    {
                        polkkeysums[polk] += vehiclecount;
                    }

                    rowcount++;
                }
            }

            using (StreamWriter zipcountoutfile = new StreamWriter(zipcountsfile))
            {
                HashSet<string> zipwasfound = new HashSet<string>();

                zipcountoutfile.WriteLine("State, Zipcode,VehicleCount");

                foreach (var state in statelookup.Keys)
                {
                    foreach (var value in statelookup[state])
                    {
                        foreach (var zip in ziplist.Keys)
                        {
                            if (value.Contains(zip))
                            {
                                zipwasfound.Add(zip);

                                List<string> linebuilder = new List<string>();
                                linebuilder.Add(state);
                                linebuilder.Add(zip);
                                linebuilder.Add(ziplist[zip].ToString());

                                zipcountoutfile.WriteLine(string.Join(deli1.ToString(), linebuilder.ToArray()));
                            }
                        }
                    }
                }

                foreach (var zip in ziplist.Keys) //check for zips that where not matched to a state.
                {
                    if (!zipwasfound.Contains(zip))
                    {
                        List<string> linebuilder = new List<string>();
                        linebuilder.Add("99"); // set artificial state code to 99. indicates zip was not found in state-zip lookup.
                        linebuilder.Add(zip);
                        linebuilder.Add(ziplist[zip].ToString());
                        zipcountoutfile.WriteLine(string.Join(deli1.ToString(), linebuilder.ToArray()));
                    }
                }
            }

            using (StreamWriter polkcountsoutfile = new StreamWriter(polkcountsfile))
            {
                polkcountsoutfile.WriteLine("Polkkey,VehicleCount");

                foreach (var polkkey in polkkeysums.Keys)
                {
                    List<string> linebuilder = new List<string>();
                    linebuilder.Add(polkkey);
                    linebuilder.Add(polkkeysums[polkkey].ToString());

                    polkcountsoutfile.WriteLine(string.Join(deli1.ToString(), linebuilder.ToArray()));
                }
            }

            string returnstring = rowcount.ToString();

            return Task.FromResult(returnstring);

        }

        static public void MichelinPOLKCountsFileCondenser(string polkdatadirectory, char deli)
        {
            //Console.Write("Drag and Drop Michelin Polk Count Data Files Folder here: ");
            //string polkdatadirectory = Console.ReadLine();
            string[] michelinpolkdatafilepaths = Directory.GetFiles(polkdatadirectory);
            //char deli = GetDelimiter();
            char txtq = '"';
            Console.WriteLine();

            string splitfilefolderpath = GetDesktopDirectory() + @"\michelin_uspolk_counts\";
            string polkcountsfile = splitfilefolderpath + "\\" + "polk_counts.txt";

            Dictionary<string, int> uspolkcounts = new Dictionary<string, int>();

            foreach (var file in michelinpolkdatafilepaths)
            {
                using (StreamReader polkcountfile = new StreamReader(file))
                {
                    polkcountfile.ReadLine();

                    string line = string.Empty;
                    while ((line = polkcountfile.ReadLine()) != null)
                    {
                        List<string> splitlinebuilder = new List<string>();
                        if (line.Contains(txtq))
                        {
                            splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, deli, txtq, false));
                        }
                        else
                        {
                            splitlinebuilder.AddRange(line.Split(deli));
                        }

                        string[] splitline = splitlinebuilder.ToArray();
                        string polkkey = splitline[0].Replace(txtq.ToString(), "");
                        int vehiclecount = Int32.Parse(splitline[1].Replace(txtq.ToString(), ""));

                        if (!uspolkcounts.ContainsKey(polkkey))
                        {
                            uspolkcounts.Add(polkkey, vehiclecount);
                        }
                        else
                        {
                            uspolkcounts[polkkey] += vehiclecount;
                        }
                    }
                }
            }

            using (StreamWriter polkcountsoutfile = new StreamWriter(polkcountsfile))
            {
                var totalvehicles = uspolkcounts.Sum(vehiclecount => vehiclecount.Value);

                polkcountsoutfile.WriteLine("Polkkey,VehicleCount - {0}", totalvehicles);

                foreach (var polkkey in uspolkcounts.Keys)
                {
                    List<string> linebuilder = new List<string>();
                    linebuilder.Add(polkkey);
                    linebuilder.Add(uspolkcounts[polkkey].ToString());

                    polkcountsoutfile.WriteLine(string.Join(deli.ToString(), linebuilder.ToArray()));
                }
            }
        }

        static public void MichelinPOLKZipCountsFileCondenser(string zipdatadirectory, char deli)
        {
            //Console.Write("Drag and Drop Michelin Zip Count Data Files Folder here: ");
            //string zipdatadirectory = Console.ReadLine();
            string[] michelinzipdatafilepaths = Directory.GetFiles(@zipdatadirectory);
            //char deli = GetDelimiter();
            char txtq = '"';
            Console.WriteLine();

            string splitfilefolderpath = GetDesktopDirectory() + @"\michelin_uspolk_counts\";
            string zipcountsfile = splitfilefolderpath + "\\" + "zip_counts.txt";
            string statecountsfile = splitfilefolderpath + "\\" + "state_counts.txt";

            // state key, zipcode key, vehicle count
            Dictionary<string, Dictionary<string, int>> uszipcounts = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> usstatescounts = new Dictionary<string, int>();

            foreach (var file in michelinzipdatafilepaths)
            {
                using (StreamReader zipcountfile = new StreamReader(file))
                {
                    zipcountfile.ReadLine(); //read headers.

                    string line = string.Empty;
                    while ((line = zipcountfile.ReadLine()) != null)
                    {
                        List<string> splitlinebuilder = new List<string>();
                        if (line.Contains(txtq))
                        {
                            splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, deli, txtq, false));
                        }
                        else
                        {
                            splitlinebuilder.AddRange(line.Split(deli));
                        }

                        string[] splitline = splitlinebuilder.ToArray();
                        string statecode = splitline[0].Replace(txtq.ToString(), "");
                        string zip = splitline[1].Replace(txtq.ToString(), "");
                        int vehiclecount = Int32.Parse(splitline[2].Replace(txtq.ToString(), ""));

                        if (!uszipcounts.ContainsKey(statecode)) // if the state dictionary does not have the state.
                        {
                            Dictionary<string, int> tempdict = new Dictionary<string, int>();
                            tempdict.Add(zip, vehiclecount); // zip code and vehicle count new state line saved to temp dict. copied into uslevel dict.
                            uszipcounts.Add(statecode, tempdict);
                        }
                        else
                        {
                            if (!uszipcounts[statecode].ContainsKey(zip)) //if the nested dictionary doesnt contain the zip.
                            {
                                uszipcounts[statecode].Add(zip, vehiclecount);
                            }
                            else
                            {
                                uszipcounts[statecode][zip] += vehiclecount; //if the zipcode is already in the us level dict. add to vehicle count.
                            }
                        }

                        if (!usstatescounts.ContainsKey(statecode))
                        {
                            usstatescounts.Add(statecode, vehiclecount);
                        }
                        else
                        {
                            usstatescounts[statecode] += vehiclecount;
                        }
                    }
                }
            }

            using (StreamWriter zipcountsoutfile = new StreamWriter(zipcountsfile))
            {
                long totalvehiclecount = 0;

                foreach (var state in uszipcounts.Keys)
                {
                    Dictionary<string, int> tempdict = uszipcounts[state];

                    totalvehiclecount += tempdict.Sum(vehiclecount => vehiclecount.Value);
                }

                zipcountsoutfile.WriteLine("StateCode,ZipCode,VehicleCount - {0}", totalvehiclecount);

                foreach (var statecode in uszipcounts.Keys)
                {
                    foreach (var zip in uszipcounts[statecode].Keys)
                    {
                        List<string> linebuilder = new List<string>();
                        linebuilder.Add(statecode);
                        linebuilder.Add(zip);
                        linebuilder.Add(uszipcounts[statecode][zip].ToString());

                        zipcountsoutfile.WriteLine(string.Join(deli.ToString(), linebuilder.ToArray()));
                    }
                }
            }

            using (StreamWriter statecountsoutfile = new StreamWriter(statecountsfile)) // unsorted output. can sort using hash or list of the keys, output based on that.
            {
                statecountsoutfile.WriteLine("StateCode,VehicleCount");
                foreach (var state in usstatescounts.Keys)
                {
                    List<string> linebuilder = new List<string>();
                    linebuilder.Add(state);
                    linebuilder.Add(usstatescounts[state].ToString());

                    statecountsoutfile.WriteLine(string.Join(deli.ToString(), linebuilder.ToArray()));
                }
            }
        }

        // looks for added or dropped zip codes.
        static public void MichelinPOLKNewZipFinder()
        {
            // use previously created zip counts files.

            Console.WriteLine("-Enter Current Year Zip Counts file-");
            string currentyearfile = GetAFile();
            char currentyeardeli = GetDelimiter();
            Console.WriteLine();

            Console.WriteLine("-Enter Last Year Zip Counts file-");
            string lasatyearfile = GetAFile();
            char lastyeardeli = GetDelimiter();
            Console.WriteLine();

            char txtq = '"';
            string splitfilefolderpath = GetDesktopDirectory() + @"\michelin_uspolk_counts";
            if (!Directory.Exists(splitfilefolderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(splitfilefolderpath);
            }

            string newziplist = splitfilefolderpath + "\\" + GetFileNameWithoutExtension(currentyearfile) + "_newzips.txt";
            string droppedziplist = splitfilefolderpath + "\\" + GetFileNameWithoutExtension(currentyearfile) + "_drops.txt";

            HashSet<string> newzips = new HashSet<string>();
            HashSet<string> droppedzips = new HashSet<string>();

            HashSet<string> currentuniquezips = new HashSet<string>();
            HashSet<string> lastuniquezips = new HashSet<string>();
            int currentuniquecounter = 0;
            int lastuniquecounter = 0;
            string header = string.Empty;

            using (StreamReader currentfile = new StreamReader(currentyearfile))
            {
                header = currentfile.ReadLine(); // header read

                //add check to find the zip_code column.

                string line = string.Empty;
                while ((line = currentfile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();

                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, currentyeardeli, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(currentyeardeli));
                    }

                    string[] splitline = splitlinebuilder.ToArray();
                    int geoidindex = 1; // add checks for if contains txtqs requires rewrite of alot of methods.

                    currentuniquezips.Add(splitline[geoidindex]);

                    currentuniquecounter = currentuniquezips.Count;
                }
            }

            using (StreamReader lastfile = new StreamReader(lasatyearfile))
            {
                lastfile.ReadLine(); // header read

                //add check to find the zip_code column.

                string line = string.Empty;
                while ((line = lastfile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();

                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, currentyeardeli, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(currentyeardeli));
                    }

                    string[] splitline = splitlinebuilder.ToArray();
                    int geoidindex = 1; // add checks for if contains txtqs requires rewrite of alot of methods.

                    lastuniquezips.Add(splitline[geoidindex]);

                    lastuniquecounter = lastuniquezips.Count;
                }
            }

            foreach (var zip in currentuniquezips)
            {
                if (!lastuniquezips.Contains(zip))
                {
                    newzips.Add(zip);
                }
            }

            foreach (var zip in lastuniquezips)
            {
                if (!currentuniquezips.Contains(zip))
                {
                    droppedzips.Add(zip);
                }
            }

            using (StreamWriter newzipsfile = new StreamWriter(newziplist))
            {
                List<string> splitlinebuilder = new List<string>();

                if (header.Contains(txtq))
                {
                    splitlinebuilder.AddRange(SplitLineWithTxtQualifier(header, currentyeardeli, txtq, false));
                }
                else
                {
                    splitlinebuilder.AddRange(header.Split(currentyeardeli));
                }

                string[] splitheader = splitlinebuilder.ToArray();
                string geoname = splitheader[1].Trim();
                newzipsfile.WriteLine("{0}", geoname); //header

                foreach (var zip in newzips)
                {
                    newzipsfile.WriteLine(zip);
                }
            }

            using (StreamWriter droppedzipsfile = new StreamWriter(droppedziplist))
            {
                List<string> splitlinebuilder = new List<string>();

                if (header.Contains(txtq))
                {
                    splitlinebuilder.AddRange(SplitLineWithTxtQualifier(header, currentyeardeli, txtq, false));
                }
                else
                {
                    splitlinebuilder.AddRange(header.Split(currentyeardeli));
                }

                string[] splitheader = splitlinebuilder.ToArray();
                string geoname = splitheader[1].Trim();
                droppedzipsfile.WriteLine("{0}", geoname); //header

                foreach (var zip in droppedzips)
                {
                    droppedzipsfile.WriteLine(zip);
                }
            }
        }


        // summarize outputs from file condensers and compare to last year.
        static public void MichelinPOLKZipCountsDiffReader()
        {
            Console.WriteLine("-Enter Current Year Zip Counts file-");
            string currentyearfile = GetAFile();
            char currentyeardeli = GetDelimiter();
            Console.WriteLine();

            Console.WriteLine("-Enter Last Year Zip Counts file-");
            string lasatyearfile = GetAFile();
            char lastyeardeli = GetDelimiter();
            Console.WriteLine();

            //Console.Write("Current Vintage Year: ");
            //string currentyear = Console.ReadLine().Trim();

            char txtq = '"';

            string filefolderpath = GetDesktopDirectory() + @"\michelin_uspolk_counts";
            if (!Directory.Exists(filefolderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(filefolderpath);
            }

            string percentdifffile = filefolderpath + "\\" + GetFileNameWithoutExtension(currentyearfile) + "_difs.csv";

            //Dictionary<string, int> currentyeardata = new Dictionary<string, int>();
            Dictionary<string, Dictionary<string, int>> currentyeardata = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, Dictionary<string, int>> lastyeardata = new Dictionary<string, Dictionary<string, int>>();

            using (StreamReader currentfile = new StreamReader(currentyearfile))
            {
                string currentheader = currentfile.ReadLine(); // read header

                string line = string.Empty;

                while ((line = currentfile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, currentyeardeli, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(currentyeardeli));
                    }

                    string[] splitline = splitlinebuilder.ToArray();

                    string statecode = splitline[0].Replace(txtq.ToString(), "");
                    string zip = splitline[1].Replace(txtq.ToString(), "");
                    int vehiclecount = Int32.Parse(splitline[2].Replace(txtq.ToString(), ""));


                    if (!currentyeardata.ContainsKey(statecode)) // if the state dictionary does not have the state.
                    {
                        Dictionary<string, int> tempdict = new Dictionary<string, int>();
                        tempdict.Add(zip, vehiclecount); // zip code and vehicle count new state line saved to temp dict. copied into uslevel dict.
                        currentyeardata.Add(statecode, tempdict);
                    }
                    else
                    {
                        if (!currentyeardata[statecode].ContainsKey(zip)) //if the nested dictionary doesnt contain the zip.
                        {
                            currentyeardata[statecode].Add(zip, vehiclecount);
                        }
                        else
                        {
                            currentyeardata[statecode][zip] += vehiclecount; //if the zipcode is already in the us level dict. add to vehicle count.
                        }
                    }
                }
            }

            using (StreamReader lastfile = new StreamReader(lasatyearfile))
            {
                string lastheader = lastfile.ReadLine(); // read header

                string line = string.Empty;

                while ((line = lastfile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, currentyeardeli, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(currentyeardeli));
                    }

                    string[] splitline = splitlinebuilder.ToArray();

                    string statecode = splitline[0].Replace(txtq.ToString(), "");
                    string zip = splitline[1].Replace(txtq.ToString(), "");
                    int vehiclecount = Int32.Parse(splitline[2].Replace(txtq.ToString(), ""));


                    if (!lastyeardata.ContainsKey(statecode)) // if the state dictionary does not have the state.
                    {
                        Dictionary<string, int> tempdict = new Dictionary<string, int>();
                        tempdict.Add(zip, vehiclecount); // zip code and vehicle count new state line saved to temp dict. copied into uslevel dict.
                        lastyeardata.Add(statecode, tempdict);
                    }
                    else
                    {
                        if (!lastyeardata[statecode].ContainsKey(zip)) //if the nested dictionary doesnt contain the zip.
                        {
                            lastyeardata[statecode].Add(zip, vehiclecount);
                        }
                        else
                        {
                            lastyeardata[statecode][zip] += vehiclecount; //if the zipcode is already in the us level dict. add to vehicle count.
                        }
                    }
                }
            }

            using (StreamWriter percentdiffoutfile = new StreamWriter(percentdifffile))
            {
                percentdiffoutfile.WriteLine("StateCode, ZipCode, LastYearVehicleCount, CurrentyearVehicleCount, %Diff");

                foreach (var state in currentyeardata.Keys)
                {
                    foreach (var zip in currentyeardata[state].Keys)
                    {
                        if (lastyeardata.ContainsKey(state))
                        {
                            if (lastyeardata[state].ContainsKey(zip))
                            {
                                double percentdiff = 0;

                                if (lastyeardata[state][zip] != 0)
                                {
                                    // [(V2-V1) / |V1|) *100] (V1 = last year value, V2 = current year value)
                                    double currentvalue = currentyeardata[state][zip];
                                    double lastvalue = lastyeardata[state][zip];

                                    percentdiff = ((currentvalue - lastvalue) / Math.Abs(lastvalue)) * 100;
                                }
                                else
                                {
                                    percentdiff = currentyeardata[state][zip] * 100;
                                }

                                List<string> linebuilder = new List<string>();
                                linebuilder.Add(state); // state
                                linebuilder.Add(zip); // zip
                                linebuilder.Add(lastyeardata[state][zip].ToString());
                                linebuilder.Add(currentyeardata[state][zip].ToString());
                                linebuilder.Add(percentdiff.ToString() + "%");

                                percentdiffoutfile.WriteLine(string.Join(currentyeardeli.ToString(), linebuilder.ToArray()));
                            }
                        }
                    }
                }
            }
        }

        static public void MichelinPOLKPolkKeyCountsDiffReader()
        {
            Console.WriteLine("-Enter Current Year PolkKey Counts file-");
            string currentyearfile = GetAFile();
            char currentyeardeli = GetDelimiter();
            Console.WriteLine();

            Console.WriteLine("-Enter Last Year PolkKey Counts file-");
            string lasatyearfile = GetAFile();
            char lastyeardeli = GetDelimiter();
            Console.WriteLine();

            //Console.Write("Current Vintage Year: ");
            //string currentyear = Console.ReadLine().Trim();

            char txtq = '"';

            string filefolderpath = GetDesktopDirectory() + @"\michelin_uspolk_counts";
            if (!Directory.Exists(filefolderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(filefolderpath);
            }

            string percentdifffile = filefolderpath + "\\" + GetFileNameWithoutExtension(currentyearfile) + "_difs.csv";

            Dictionary<string, int> currentyeardata = new Dictionary<string, int>();
            Dictionary<string, int> lastyeardata = new Dictionary<string, int>();

            using (StreamReader currentfile = new StreamReader(currentyearfile))
            {
                string currentheader = currentfile.ReadLine(); // read header

                string line = string.Empty;

                while ((line = currentfile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, currentyeardeli, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(currentyeardeli));
                    }

                    string[] splitline = splitlinebuilder.ToArray();

                    string polkkey = splitline[0].Replace(txtq.ToString(), "");
                    int vehiclecount = Int32.Parse(splitline[1].Replace(txtq.ToString(), ""));

                    if (!currentyeardata.ContainsKey(polkkey)) //if the nested dictionary doesnt contain the zip.
                    {
                        currentyeardata.Add(polkkey, vehiclecount);
                    }
                    else
                    {
                        currentyeardata[polkkey] += vehiclecount; //if the zipcode is already in the us level dict. add to vehicle count.
                    }
                }
            }

            using (StreamReader lastfile = new StreamReader(lasatyearfile))
            {
                string currentheader = lastfile.ReadLine(); // read header

                string line = string.Empty;

                while ((line = lastfile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, currentyeardeli, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(currentyeardeli));
                    }

                    string[] splitline = splitlinebuilder.ToArray();

                    string polkkey = splitline[0].Replace(txtq.ToString(), "");
                    int vehiclecount = Int32.Parse(splitline[1].Replace(txtq.ToString(), ""));

                    if (!lastyeardata.ContainsKey(polkkey)) //if the nested dictionary doesnt contain the zip.
                    {
                        lastyeardata.Add(polkkey, vehiclecount);
                    }
                    else
                    {
                        lastyeardata[polkkey] += vehiclecount; //if the zipcode is already in the us level dict. add to vehicle count.
                    }
                }
            }

            using (StreamWriter percentdiffoutfile = new StreamWriter(percentdifffile))
            {
                percentdiffoutfile.WriteLine("PolkKey, LastYearVehicleCount, CurrentyearVehicleCount, %Diff");

                foreach (var polkkey in currentyeardata.Keys)
                {
                    if (lastyeardata.ContainsKey(polkkey))
                    {
                        double percentdiff = 0;

                        if (lastyeardata[polkkey] != 0)
                        {
                            // [(V2-V1) / |V1|) *100] (V1 = last year value, V2 = current year value)
                            double currentvalue = currentyeardata[polkkey];
                            double lastvalue = lastyeardata[polkkey];

                            percentdiff = ((currentvalue - lastvalue) / Math.Abs(lastvalue)) * 100;
                        }
                        else
                        {
                            percentdiff = currentyeardata[polkkey] * 100;
                        }

                        List<string> linebuilder = new List<string>();
                        linebuilder.Add(polkkey); // state
                        linebuilder.Add(lastyeardata[polkkey].ToString());
                        linebuilder.Add(currentyeardata[polkkey].ToString());
                        linebuilder.Add(percentdiff.ToString() + "%");

                        percentdiffoutfile.WriteLine(string.Join(currentyeardeli.ToString(), linebuilder.ToArray()));
                    }
                }
            }
        }

        static public void MichelinPOLKStateCountsDiffReader() // same code as MIchelinPolkKeyCountsDiffReader() just uses state names instead of polk key.
        {
            Console.WriteLine("-Enter Current Year State Counts file-");
            string currentyearfile = GetAFile();
            char currentyeardeli = GetDelimiter();
            Console.WriteLine();

            Console.WriteLine("-Enter Last Year State Counts file-");
            string lasatyearfile = GetAFile();
            char lastyeardeli = GetDelimiter();
            Console.WriteLine();

            //Console.Write("Current Vintage Year: ");
            //string currentyear = Console.ReadLine().Trim();

            char txtq = '"';

            string filefolderpath = GetDesktopDirectory() + @"\michelin_uspolk_counts";
            if (!Directory.Exists(filefolderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(filefolderpath);
            }

            string percentdifffile = filefolderpath + "\\" + GetFileNameWithoutExtension(currentyearfile) + "_difs.csv";

            Dictionary<string, int> currentyeardata = new Dictionary<string, int>();
            Dictionary<string, int> lastyeardata = new Dictionary<string, int>();

            using (StreamReader currentfile = new StreamReader(currentyearfile))
            {
                string currentheader = currentfile.ReadLine(); // read header

                string line = string.Empty;

                while ((line = currentfile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, currentyeardeli, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(currentyeardeli));
                    }

                    string[] splitline = splitlinebuilder.ToArray();

                    string statecode = splitline[0].Replace(txtq.ToString(), "");
                    int vehiclecount = Int32.Parse(splitline[1].Replace(txtq.ToString(), ""));

                    if (!currentyeardata.ContainsKey(statecode)) //if the nested dictionary doesnt contain the zip.
                    {
                        currentyeardata.Add(statecode, vehiclecount);
                    }
                    else
                    {
                        currentyeardata[statecode] += vehiclecount; //if the zipcode is already in the us level dict. add to vehicle count.
                    }
                }
            }

            using (StreamReader lastfile = new StreamReader(lasatyearfile))
            {
                string currentheader = lastfile.ReadLine(); // read header

                string line = string.Empty;

                while ((line = lastfile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, currentyeardeli, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(currentyeardeli));
                    }

                    string[] splitline = splitlinebuilder.ToArray();

                    string statecode = splitline[0].Replace(txtq.ToString(), "");
                    int vehiclecount = Int32.Parse(splitline[1].Replace(txtq.ToString(), ""));

                    if (!lastyeardata.ContainsKey(statecode)) //if the nested dictionary doesnt contain the zip.
                    {
                        lastyeardata.Add(statecode, vehiclecount);
                    }
                    else
                    {
                        lastyeardata[statecode] += vehiclecount; //if the zipcode is already in the us level dict. add to vehicle count.
                    }
                }
            }

            using (StreamWriter percentdiffoutfile = new StreamWriter(percentdifffile))
            {
                percentdiffoutfile.WriteLine("StateCode, LastYearVehicleCount, CurrentyearVehicleCount, %Diff");

                foreach (var statecode in currentyeardata.Keys)
                {
                    if (lastyeardata.ContainsKey(statecode))
                    {
                        double percentdiff = 0;

                        if (lastyeardata[statecode] != 0)
                        {
                            // [(V2-V1) / |V1|) *100] (V1 = last year value, V2 = current year value)
                            double currentvalue = currentyeardata[statecode];
                            double lastvalue = lastyeardata[statecode];

                            percentdiff = ((currentvalue - lastvalue) / Math.Abs(lastvalue)) * 100;
                        }
                        else
                        {
                            percentdiff = currentyeardata[statecode] * 100;
                        }

                        List<string> linebuilder = new List<string>();
                        linebuilder.Add(statecode); // state
                        linebuilder.Add(lastyeardata[statecode].ToString());
                        linebuilder.Add(currentyeardata[statecode].ToString());
                        linebuilder.Add(percentdiff.ToString() + "%");

                        percentdiffoutfile.WriteLine(string.Join(currentyeardeli.ToString(), linebuilder.ToArray()));
                    }
                }
            }
        }

        // other qa tasks.
        static public void MichelinPOLKVehicleInfoFileCleaner() // clean the new vehicle file first
        {
            // expected header: POLK_KEY,YEAR_MODEL,MAKE_NAME,MODEL_NAME,TRIM_NAME,SEGMENT_NAME

            // add check for 'blanks' -> change blanks to 'N/A'

            Console.WriteLine("-Enter Current Year Vehicle Data file-");
            string file = GetAFile();
            char deli = GetDelimiter();
            char txtq = GetTXTQualifier();
            Console.WriteLine();

            string filefolderpath = GetDesktopDirectory() + @"\michelin_uspolk_counts";
            if (!Directory.Exists(filefolderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(filefolderpath);
            }

            string cleanedfile = filefolderpath + "\\" + GetFileNameWithoutExtension(file) + "cleaned.txt";

            using (StreamReader vehiclecountsfile = new StreamReader(file))
            {
                using (StreamWriter cleanedvehiclefile = new StreamWriter(cleanedfile))
                {
                    string header = vehiclecountsfile.ReadLine();
                    cleanedvehiclefile.WriteLine(header);
                    List<string> headersplitbuilder = new List<string>();

                    if (header.Contains(txtq))
                    {
                        headersplitbuilder.AddRange(SplitLineWithTxtQualifier(header, deli, txtq, false));
                    }
                    else
                    {
                        headersplitbuilder.AddRange(header.Split(deli));
                    }

                    string year = "YEAR_MODEL"; // find the index of this column. hard coded for now.

                    int yearindex = headersplitbuilder.IndexOf(year); // trying out new method. shorter.

                    string line = string.Empty;
                    int counter = 0;
                    while ((line = vehiclecountsfile.ReadLine()) != null)
                    {
                        List<string> splitlinebuilder = new List<string>();
                        if (line.Contains(txtq))
                        {
                            splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, deli, txtq, false));
                        }
                        else
                        {
                            splitlinebuilder.AddRange(line.Split(deli));
                        }

                        string[] splitline = splitlinebuilder.ToArray();

                        if (splitline[yearindex].ToCharArray().Count() != 4)
                        {
                            splitline[yearindex] = "0001";
                            counter++;
                        }

                        cleanedvehiclefile.WriteLine(string.Join(deli.ToString(), splitline));
                    }

                    Console.WriteLine();
                    Console.WriteLine("Records changed - {0}", counter);
                }
            }
        }

        static public void MichelinPOLKMichelintoPolkCrossWalk() // do the vehicle file crosswalk 
        {
            // uses vehicle data file from polk and the 
            // e1platform tables (make, model, year, trim) should match
            //    stage_polk_lookup -> michelin_vehicle_data_201810.csv (from polk)
            //
            //    mich_polk_lookup -> 2019 US Polk Summary Final - Nuestar.csv (from michelin)   

            //check the unique (make, model, year, trim) from each new file against eachother
            // check the unique (make, model, year, trim) from new to old data????? 


            // stage_polk_lookup -> michelin_vehicle_data_201810.csv
            Console.WriteLine("- Enter Polk Vehicle Count File -");
            string polkdatafile = GetAFile();
            char polkdeli = GetDelimiter();

            Console.WriteLine("- Enter Michelin Vehicle Count File -");
            string michelindatafile = GetAFile();
            char michelindeli = GetDelimiter();

            char txtq = GetTXTQualifier(); // "

            Console.Write("Current Vintage Year: ");
            string currentyear = Console.ReadLine().Trim();

            Dictionary<string, int> polkvehicledata = new Dictionary<string, int>(); //concatenated (make, model, year, trim) will be the string, count of will be int.
            Dictionary<string, int> michelinvehicledata = new Dictionary<string, int>(); // concatenated (make, model, year, trim) will be the string, count of will be int.

            Dictionary<string, List<string>> polkvehiclenames = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> michelinvehiclenames = new Dictionary<string, List<string>>();

            string filefolderpath = GetDesktopDirectory() + @"\michelin_uspolk_counts";
            if (!Directory.Exists(filefolderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(filefolderpath);
            }

            string vehicleinfofile = filefolderpath + "\\" + currentyear + "_vehicleinfo.csv";

            using (StreamReader readpolkfile = new StreamReader(polkdatafile))
            {
                string header = readpolkfile.ReadLine();

                //add check to verify that the columns are in the same position.... hard coding for now.
                // need to have the whole header in order to print out and verify on screen.

                string year = "YEAR_MODEL";
                string make = "Make_NAME";
                string model = "MODEL_NAME";
                string trim = "TRIM_NAME";

                int yearindex = ColumnIndex(header, polkdeli, year);
                int makeindex = ColumnIndex(header, polkdeli, make);
                int modelindex = ColumnIndex(header, polkdeli, model);
                int trimindex = ColumnIndex(header, polkdeli, trim);

                string line = string.Empty;
                int linecount = 0;
                while ((line = readpolkfile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, polkdeli, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(polkdeli));
                    }

                    string[] splitline = splitlinebuilder.ToArray();

                    string concateddictkey = splitline[yearindex] + splitline[makeindex] + splitline[modelindex] + splitline[trimindex];

                    List<string> vehiclenameinfo = new List<string>();
                    vehiclenameinfo.Add(splitline[yearindex]);
                    vehiclenameinfo.Add(splitline[makeindex]);
                    vehiclenameinfo.Add(splitline[modelindex]);
                    vehiclenameinfo.Add(splitline[trimindex]);


                    if (!polkvehicledata.ContainsKey(concateddictkey))
                    {
                        polkvehicledata.Add(concateddictkey, 1);
                    }
                    else
                    {
                        polkvehicledata[concateddictkey] += 1;
                    }

                    if (!polkvehiclenames.ContainsKey(concateddictkey))
                    {
                        polkvehiclenames.Add(concateddictkey, vehiclenameinfo);
                    }

                    linecount++;
                }

                Console.WriteLine("{0} - record count - {1}", polkdatafile, linecount);
            }

            using (StreamReader readmichelindatafile = new StreamReader(michelindatafile))
            {
                string header = readmichelindatafile.ReadLine();
                //add check to verify that the columns are in the same position.... hard coding for now.
                // need to have the whole header in order to print out and verify on screen.

                string year = "YEAR_MODEL";
                string make = "Make_NAME";
                string model = "MODEL_NAME";
                string trim = "TRIM_NAME";

                int yearindex = ColumnIndex(header, polkdeli, year);
                int makeindex = ColumnIndex(header, polkdeli, make);
                int modelindex = ColumnIndex(header, polkdeli, model);
                int trimindex = ColumnIndex(header, polkdeli, trim);

                string line = string.Empty;
                int linecount = 0;
                while ((line = readmichelindatafile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, michelindeli, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(michelindeli));
                    }

                    string[] splitline = splitlinebuilder.ToArray();

                    string concateddictkey = splitline[yearindex] + splitline[makeindex] + splitline[modelindex] + splitline[trimindex];

                    List<string> vehiclenameinfo = new List<string>();
                    vehiclenameinfo.Add(splitline[yearindex]);
                    vehiclenameinfo.Add(splitline[makeindex]);
                    vehiclenameinfo.Add(splitline[modelindex]);
                    vehiclenameinfo.Add(splitline[trimindex]);

                    if (!michelinvehicledata.ContainsKey(concateddictkey))
                    {
                        michelinvehicledata.Add(concateddictkey, 1);
                    }
                    else
                    {
                        michelinvehicledata[concateddictkey] += 1;
                    }

                    if (!michelinvehiclenames.ContainsKey(concateddictkey))
                    {
                        michelinvehiclenames.Add(concateddictkey, vehiclenameinfo);
                    }

                    linecount++;
                }

                Console.WriteLine("{0} - record count - {1}", michelindatafile, linecount);
            }

            Dictionary<string, List<string>> michelinonly = new Dictionary<string, List<string>>();

            using (StreamWriter vehicleinfooutfile = new StreamWriter(vehicleinfofile))
            {
                List<string> headerlinebuilder = new List<string>();
                headerlinebuilder.Add("VehicleInfo");
                headerlinebuilder.Add("Count");
                headerlinebuilder.Add("SingleSource");
                headerlinebuilder.Add("PolkTrim");
                headerlinebuilder.Add("MichelinTrim");

                vehicleinfooutfile.WriteLine(string.Join(polkdeli.ToString(), headerlinebuilder.ToArray()));

                //Dictionary<string, int> tempdict = new Dictionary<string, int>();

                foreach (var vehicle in polkvehicledata.Keys)
                {
                    if (michelinvehicledata.ContainsKey(vehicle))
                    {
                        List<string> linebuilder = new List<string>();
                        linebuilder.Add(vehicle);
                        linebuilder.Add(polkvehicledata[vehicle].ToString());
                        linebuilder.Add("both");
                        linebuilder.Add("");
                        linebuilder.Add("");

                        vehicleinfooutfile.WriteLine(string.Join(polkdeli.ToString(), linebuilder.ToArray()));

                        //tempdict.Add(vehicle, polkvehicledata[vehicle]); //found
                    }
                    else
                    {
                        List<string> linebuilder = new List<string>();
                        linebuilder.Add(vehicle);
                        linebuilder.Add(polkvehicledata[vehicle].ToString());
                        linebuilder.Add("polkonly");
                        linebuilder.Add("");
                        linebuilder.Add("");

                        vehicleinfooutfile.WriteLine(string.Join(polkdeli.ToString(), linebuilder.ToArray()));
                    }
                }

                foreach (var vehicle in michelinvehicledata.Keys)
                {

                    if (!polkvehicledata.ContainsKey(vehicle))
                    {
                        List<string> tempmichelinname = michelinvehiclenames[vehicle];

                        bool found = false;

                        foreach (var polkvehicle in polkvehiclenames.Keys) // loop through the name list dict. compare list values. if at least 3 values match output.
                        {
                            List<string> temppolkname = polkvehiclenames[polkvehicle];

                            int year = 0; // all are previously found. add code to save the list indexes when they are added to the lsits.
                            int make = 1;
                            int model = 2;
                            int trim = 3;

                            if (temppolkname[year] == temppolkname[year] && temppolkname[make] == temppolkname[make] && temppolkname[model] == temppolkname[model])
                            {
                                if (temppolkname[trim] != temppolkname[trim])
                                {
                                    found = true;
                                    List<string> linebuilder = new List<string>();
                                    linebuilder.Add(vehicle);
                                    linebuilder.Add(michelinvehicledata[vehicle].ToString());
                                    linebuilder.Add("michelinonly");
                                    linebuilder.Add(temppolkname[trim]);
                                    linebuilder.Add(tempmichelinname[trim]);

                                    vehicleinfooutfile.WriteLine(string.Join(polkdeli.ToString(), linebuilder.ToArray()));
                                }
                            }
                        }

                        if (found == false)
                        {
                            michelinonly.Add(vehicle, tempmichelinname);

                            List<string> linebuilder = new List<string>();
                            linebuilder.Add(vehicle);
                            linebuilder.Add(michelinvehicledata[vehicle].ToString());
                            linebuilder.Add("michelinonly");
                            linebuilder.Add("");
                            linebuilder.Add("");

                            vehicleinfooutfile.WriteLine(string.Join(polkdeli.ToString(), linebuilder.ToArray()));
                        }
                    }
                }
            }

            string michelinonlyfile = filefolderpath + "\\michelinonly-vehicles.csv";
            using (StreamWriter michelinonlyoutfile = new StreamWriter(michelinonlyfile))
            {
                List<string> headerlinebuilder = new List<string>();
                headerlinebuilder.Add("VehicleInfo");
                headerlinebuilder.Add("Year");
                headerlinebuilder.Add("Make");
                headerlinebuilder.Add("Model");
                headerlinebuilder.Add("Trim");

                michelinonlyoutfile.WriteLine(string.Join(polkdeli.ToString(), headerlinebuilder.ToArray()));

                foreach (var vehicle in michelinonly.Keys)
                {
                    List<string> linebuilder = new List<string>();
                    linebuilder.Add(vehicle);

                    foreach (var value in michelinonly[vehicle])
                    {
                        linebuilder.Add(value);
                    }

                    michelinonlyoutfile.WriteLine(string.Join(polkdeli.ToString(), linebuilder.ToArray()));
                }
            }

            int polkunique = polkvehicledata.Count;
            int michelinunique = michelinvehicledata.Count;

            Console.WriteLine();
            Console.WriteLine("{0} - Polk Unique Vehicles", polkunique);
            Console.WriteLine("{0} - Michelin Unique Vehicles", michelinunique);

        }

        static public void MichelinPOLKTirePotentialSegmentChecker() // check the TP_SEG columns 
        {
            // e1platform mich_polk_lookup table tp_seg column should match us_usage_table table tp_seg column
            // mich_polk_lookup table is updated with the "2019 US Polk Summary Final - Nuestar.csv" file from michelin.
            // us_usage_table table is updated with the "2019 US Usage-v1.csv" file from michelin.
            // TP_SEG is Group_Cat and Standard_Tire_Size concatenated 


            // Each TP_SEG entry in the US Usage file should be unique...
            // Compare uniques from both files. 
            // Output a file with two columns, matching ... US-Usage-TPseg , Summary-File-TPSEG
            // non-matches are listed as "tpseg" , "no match" in appropriate columns

            Console.WriteLine("-Enter US Usage File-");
            string ususagefile = GetAFile();
            char ususagedeli = GetDelimiter();
            char txtq = GetTXTQualifier();

            Console.WriteLine();
            Console.WriteLine("-Enter US Summary File-");
            string ussummaryfile = GetAFile();
            char ussummarydeli = GetDelimiter();
            // char txtq = GetTXTQualifier();

            string filefolderpath = GetDesktopDirectory() + @"\michelin_uspolk_counts";
            if (!Directory.Exists(filefolderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(filefolderpath);
            }

            string tpsegfile = filefolderpath + "\\tpsegments.txt";
            char newdeli = '\t'; // tab

            HashSet<string> ususagetpsegs = new HashSet<string>();
            HashSet<string> ussummarytpsegs = new HashSet<string>();

            int matches = 0;
            int ussummaryrecords = 0;
            int ususagerecords = 0;

            using (StreamReader ususagereadfile = new StreamReader(ususagefile))
            {
                string header = ususagereadfile.ReadLine();

                string tpsegname = "TP_SEG"; //column index finder puts everything .toupper().

                //Int32 tpsegindex; //system.int32
                int tpsegindex = 0; // primative data type. does not allow for null values.

                try
                {
                    tpsegindex = ColumnIndexWithQualifier(header, ususagedeli, txtq, tpsegname);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }

                string line = string.Empty;
                while ((line = ususagereadfile.ReadLine()) != null)
                {
                    List<string> arraybuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        arraybuilder.AddRange(SplitLineWithTxtQualifier(line, ususagedeli, txtq, false));
                    }
                    else
                    {
                        arraybuilder.AddRange(line.Split(ususagedeli));
                    }

                    string[] splitline = arraybuilder.ToArray();
                    bool added = ususagetpsegs.Add(splitline[tpsegindex]);

                    if (added == true)
                    {
                        ususagerecords++;
                    }
                }
            }

            using (StreamReader ussummaryreadfile = new StreamReader(ussummaryfile))
            {
                string header = ussummaryreadfile.ReadLine();

                string tpsegname = "TP_SEG"; //column index finder puts everything .toupper().

                //Int32 tpsegindex; //system.int32
                int tpsegindex = 0; // primative data type. does not allow for null values.

                try
                {
                    tpsegindex = ColumnIndexWithQualifier(header, ususagedeli, txtq, tpsegname);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }

                string line = string.Empty;
                while ((line = ussummaryreadfile.ReadLine()) != null)
                {
                    List<string> arraybuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        arraybuilder.AddRange(SplitLineWithTxtQualifier(line, ususagedeli, txtq, false));
                    }
                    else
                    {
                        arraybuilder.AddRange(line.Split(ususagedeli));
                    }

                    string[] splitline = arraybuilder.ToArray();
                    bool added = ussummarytpsegs.Add(splitline[tpsegindex]);

                    if (added == true)
                    {
                        ussummaryrecords++;
                    }
                }
            }


            using (StreamWriter tpsegoutfile = new StreamWriter(tpsegfile))
            {
                tpsegoutfile.WriteLine("{0}{1}{2}", "US_Summary_TP_SEG", newdeli, "US_Usage_TP_SEG");

                foreach (var x in ussummarytpsegs)
                {
                    if (ususagetpsegs.Contains(x))
                    {
                        tpsegoutfile.WriteLine("{0}{1}{2}", x, newdeli, x);
                        matches++;
                    }
                    else
                    {
                        tpsegoutfile.WriteLine("{0}{1}{2}", x, newdeli, "");
                    }
                }

                foreach (var x in ususagetpsegs)
                {
                    if (!ussummarytpsegs.Contains(x))
                    {
                        tpsegoutfile.WriteLine("{0}{1}{2}", "", newdeli, x);
                    }
                }
            }

            Console.WriteLine("{0} - US Usage Tp_Segs", ususagerecords);
            Console.WriteLine("{0} - US Summary Tp_Segs", ussummaryrecords);
            Console.WriteLine("{0} - Matches", matches);
        }

        static public void MichelinPOLKGroupCatChecker() // Check if the Group_Categories align between the active_mspns1 and mich_polk_lookup files
        {
            // ACTIVE_MSPNS1 table, columns "GROUPE_CATEGORY", "TIRE_SIZE"
            // 2019-US-PolkSummary-Final.csv file, columns "Group_Cat", "Standard_Tire_Size"

            // look at TIRE_SIZES. then compare on tire size + group category,

            Console.WriteLine("-Enter ACTIVE MSPN File-");
            string activemspnfile = GetAFile();
            char activemspndeli = GetDelimiter();
            char txtq = GetTXTQualifier();

            Console.WriteLine();
            Console.WriteLine("-Enter US Summary File-");
            string ussummaryfile = GetAFile();
            char ussummarydeli = GetDelimiter();
            // char txtq = GetTXTQualifier();

            string filefolderpath = GetDesktopDirectory() + @"\michelin_uspolk_counts";
            if (!Directory.Exists(filefolderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(filefolderpath);
            }

            string tiresizegroupcatfile = filefolderpath + "\\tiresizegroupcatcheckfile.txt";
            char newdeli = '\t'; // tab

            // active mspn columns GROUPE_CATEGORY TIRE_SIZE
            // summary file columns Group_Cat Standard_Tire_Size
            // group category only has 6 possible values - Rec/Com, V, Z, Winter, "ENTRY (S,T)", H.
            // "ENTRY (S,T)" - might cause issues, need to maintain the , in the data  in order to be accurate.

            // tire size will be key, categories will go into the list 
            Dictionary<string, List<string>> activemspntiregroupcategories = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> ussummarytiregroupcategories = new Dictionary<string, List<string>>();
            string[] groupcategories = { "REC/COM", "V", "Z", "Winter", "ENTRY (S,T)", "H" };

            //int matches = 0;
            //int amspntiregroups = 0;
            //int ussummarytiregroups = 0;

            using (StreamReader amspnfile = new StreamReader(activemspnfile))
            {
                string header = amspnfile.ReadLine();

                string tirecolumnname = "TIRE_SIZE";
                string groupcolumnname = "GROUPE_CATEGORY";
                int tiresizecolumn = ColumnIndexWithQualifier(header, activemspndeli, txtq, tirecolumnname);
                int groupcolumn = ColumnIndexWithQualifier(header, activemspndeli, txtq, groupcolumnname);

                string line = string.Empty;
                while ((line = amspnfile.ReadLine()) != null)
                {
                    List<string> arraybuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        arraybuilder.AddRange(SplitLineWithTxtQualifier(line, activemspndeli, txtq, false));
                    }
                    else
                    {
                        arraybuilder.AddRange(line.Split(activemspndeli));
                    }

                    string[] splitline = arraybuilder.ToArray();

                    string keytocheck = splitline[tiresizecolumn];
                    string valuetocheck = splitline[groupcolumn];

                    if (!activemspntiregroupcategories.ContainsKey(keytocheck))
                    {
                        List<string> templist = new List<string>();
                        templist.Add(valuetocheck);

                        activemspntiregroupcategories.Add(keytocheck, templist);
                    }

                    if (!activemspntiregroupcategories[keytocheck].Contains(valuetocheck))
                    {
                        activemspntiregroupcategories[keytocheck].Add(valuetocheck);
                    }
                }
            }

            using (StreamReader summaryfile = new StreamReader(ussummaryfile))
            {
                string header = summaryfile.ReadLine();

                string tirecolumnname = "Standard_Tire_Size";
                string groupcolumnname = "Group_Cat";
                int tiresizecolumn = ColumnIndexWithQualifier(header, activemspndeli, txtq, tirecolumnname);
                int groupcolumn = ColumnIndexWithQualifier(header, activemspndeli, txtq, groupcolumnname);

                string line = string.Empty;
                while ((line = summaryfile.ReadLine()) != null)
                {
                    List<string> arraybuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        arraybuilder.AddRange(SplitLineWithTxtQualifier(line, activemspndeli, txtq, false));
                    }
                    else
                    {
                        arraybuilder.AddRange(line.Split(activemspndeli));
                    }

                    string[] splitline = arraybuilder.ToArray();

                    string keytocheck = splitline[tiresizecolumn];
                    string valuetocheck = splitline[groupcolumn];

                    if (!ussummarytiregroupcategories.ContainsKey(keytocheck))
                    {
                        List<string> templist = new List<string>();
                        templist.Add(valuetocheck);

                        ussummarytiregroupcategories.Add(keytocheck, templist);
                    }

                    if (!ussummarytiregroupcategories[keytocheck].Contains(valuetocheck))
                    {
                        ussummarytiregroupcategories[keytocheck].Add(valuetocheck);
                    }
                }

            }

            using (StreamWriter outfile = new StreamWriter(tiresizegroupcatfile))
            {
                // return only records from the summary file that are not found in the active mspn file.
                // group category only has 6 possible values - Rec/Com, V, Z, Winter, "ENTRY (S,T)", H.

                List<string> header = new List<string>();
                header.Add("GroupMatchError");
                header.Add("TireSize");
                header.Add("Rec/Com");
                header.Add("V");
                header.Add("Z");
                header.Add("Winter");
                header.Add("ENTRY (S,T)");
                header.Add("H");
                outfile.WriteLine(string.Join(newdeli.ToString(), header.ToArray()));

                foreach (var tiresize in ussummarytiregroupcategories.Keys)
                {
                    if (!activemspntiregroupcategories.ContainsKey(tiresize)) // if the tire size is not found.
                    {
                        //output the tire size and the group categories.
                        string[] categories = new string[6];
                        string error = string.Empty;
                        bool matchfound = false;

                        //for (int index = 0; index < groupcategories.Length; index++)
                        //{
                        //   if (ussummarytiregroupcategories[tiresize].Contains(groupcategories[index])) 
                        //   {
                        //      categories[index] = groupcategories[index];
                        //      matchfound = true; //shows that we found at least one match.
                        //   }
                        //}

                        foreach (var category in groupcategories) //loop through all possible matches. any matches get added 
                        {
                            if (ussummarytiregroupcategories[tiresize].Contains(category))
                            {
                                int index = Array.IndexOf(groupcategories, category);
                                categories[index] = category;

                                matchfound = true;
                            }
                        }

                        if (matchfound == true)
                        {
                            List<string> linebuilder = new List<string>();
                            error = "NewTire"; // new tire has been added.
                            linebuilder.Add(error);
                            linebuilder.Add(tiresize);
                            foreach (var category in categories)
                            {
                                linebuilder.Add(category);
                            }

                            string newline = string.Join(newdeli.ToString(), linebuilder.ToArray());

                            outfile.WriteLine(newline);
                        }
                        else
                        {
                            List<string> linebuilder = new List<string>();
                            error = "NewTireNotValidCategory"; // new tire added and group category does NOT match what it should.
                            linebuilder.Add(error);
                            linebuilder.Add(tiresize);
                            foreach (var category in ussummarytiregroupcategories[tiresize]) //just write existing group categories in order they appear.
                            {
                                linebuilder.Add(category);
                            }

                            string newline = string.Join(newdeli.ToString(), linebuilder.ToArray());

                            outfile.WriteLine(newline);
                        }

                    }
                    else //tire exists.
                    {
                        string[] categories = new string[6];
                        List<string> badcategory = new List<string>();
                        string error = string.Empty;
                        string categoryvaliderror = string.Empty;
                        bool matchfound = true;
                        bool newcategory = false;

                        foreach (var category in ussummarytiregroupcategories[tiresize]) //tire exists, so compare group categories from both dictionaries.
                        {
                            if (activemspntiregroupcategories[tiresize].Contains(category)) // category found in both dicts.
                            {
                                if (!groupcategories.Contains(category)) // validate it is a good group categories. if it is good and matches do nothing.
                                {
                                    badcategory.Add(category);
                                    matchfound = false;
                                }
                            }
                            else //category not found in original file
                            {
                                if (groupcategories.Contains(category)) // validate it is a good group categories.
                                {
                                    int index = Array.IndexOf(groupcategories, category);
                                    categories[index] = category;

                                    newcategory = true;
                                }
                                else
                                {
                                    badcategory.Add(category);
                                    matchfound = false;
                                }
                            }
                        }

                        if (matchfound == false)
                        {
                            List<string> linebuilder = new List<string>();
                            categoryvaliderror = "NotValidCategory";
                            linebuilder.Add(categoryvaliderror);
                            linebuilder.Add(tiresize);
                            foreach (var category in badcategory) // write categories that do not match template.
                            {
                                linebuilder.Add(category);
                            }

                            string newline = string.Join(newdeli.ToString(), linebuilder.ToArray());

                            outfile.WriteLine(newline);
                        }

                        if (newcategory == true)
                        {
                            //tire exists but there is a new category.
                            List<string> linebuilder = new List<string>();
                            error = "NewCategory";
                            linebuilder.Add(error);
                            linebuilder.Add(tiresize);
                            foreach (var category in categories) // write categories that do not match template.
                            {
                                linebuilder.Add(category);
                            }

                            string newline = string.Join(newdeli.ToString(), linebuilder.ToArray());

                            outfile.WriteLine(newline);
                        }
                    }
                }
            }
        }


        // Canada Polk
        static public void MichelinCanadaPOLKReaderMultiTask()
        {
            // create directory for splitfiles.
            string splitfilefolderpath = GetDesktopDirectory() + @"\michelin_canadapolk_counts\splitfiles";
            string fsafilefolderpath = GetDesktopDirectory() + @"\michelin_canadapolk_counts\fsacounts";
            string polkfilefolderpath = GetDesktopDirectory() + @"\michelin_canadapolk_counts\polkcounts";

            if (!Directory.Exists(splitfilefolderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(splitfilefolderpath);
            }

            if (!Directory.Exists(polkfilefolderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(polkfilefolderpath);
            }

            if (!Directory.Exists(fsafilefolderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(fsafilefolderpath);
            }

            // get source file.
            Console.WriteLine("-Enter Polk FSA file-");
            Console.Write("File: ");
            var inFile = new FileInfo(Console.ReadLine());
            //var polkziplistfile = Console.ReadLine();
            char deli = GetDelimiter();
            char txtq = '"';
            Console.WriteLine();

            //splitfile code. (code copies from BreakOneFileIntoMany)
            Int64 sourceRecordCount, iRecordCount, NoOutputFiles;

            Console.Write("Source Record Count (Enter nothing for auto count): ");

            if (Int64.TryParse(Console.ReadLine(), out iRecordCount))
                sourceRecordCount = iRecordCount;
            else
                sourceRecordCount = File.ReadLines(inFile.FullName).LongCount();

            Console.Write("No. of Output Files: ");
            NoOutputFiles = Int64.Parse(Console.ReadLine());

            Int64 linesWritten;
            double maxBreakoutRecordsPerFile = Math.Ceiling((double)sourceRecordCount / (double)NoOutputFiles);
            string readLine;

            Console.WriteLine("Spliting file...");

            using (var reader = new StreamReader(inFile.OpenRead()))
            {
                string header = reader.ReadLine();

                for (int i = 1; i <= NoOutputFiles; i++)
                {
                    using (var writer = new StreamWriter(splitfilefolderpath + "\\" + (inFile.Name.Replace(inFile.Extension, "").ToString() + "_split_" + i + inFile.Extension.ToString())))
                    {
                        writer.WriteLine(header);
                        linesWritten = 0;

                        while (linesWritten < maxBreakoutRecordsPerFile && (readLine = reader.ReadLine()) != null)
                        {
                            writer.WriteLine(readLine);
                            linesWritten++;
                        }
                    }
                }
            }

            // read splitfiles.
            //Console.WriteLine("-Drag and Drop Michelin Zip Data Files Folder here-");
            //Console.Write("Folder: ");
            //string zipdatadirectory = Console.ReadLine();
            string[] michelinfsadatafilepaths = Directory.GetFiles(@splitfilefolderpath);

            Console.WriteLine("-Enter Province file-");
            string statefile = GetAFile();
            char statedeli = GetDelimiter();
            Console.WriteLine();

            Dictionary<string, HashSet<string>> provincefsadictionary = new Dictionary<string, HashSet<string>>();

            using (StreamReader statezipfile = new StreamReader(statefile))
            {
                string header = statezipfile.ReadLine();

                string line = string.Empty;
                while ((line = statezipfile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, statedeli, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(statedeli));
                    }

                    string[] splitline = splitlinebuilder.ToArray();
                    string provincecode = splitline[1].Replace(txtq.ToString(), ""); //hard coded to report output.
                    if (string.IsNullOrWhiteSpace(provincecode))
                    {
                        provincecode = "blank"; //accounts for states or provinces that do not appear in the province lookup files
                    }

                    string provincename = splitline[2].Replace(txtq.ToString(), "");
                    string fsa = splitline[0].Replace(txtq.ToString(), "");

                    if (!provincefsadictionary.ContainsKey(provincecode))
                    {
                        HashSet<string> temphash = new HashSet<string>();
                        temphash.Add(fsa);
                        provincefsadictionary.Add(provincecode, temphash);
                    }
                    else
                    {
                        provincefsadictionary[provincecode].Add(fsa);
                    }

                }
            }

            List<Task> tasklist = new List<Task>(); //using a task array and a file array was not working.
            try
            {
                foreach (var file in michelinfsadatafilepaths)
                {
                    var task = new Task(async () =>
                    {
                        string returned = await (MichelinCanadaPOLKfsaDataReader(file, deli, txtq, provincefsadictionary));
                        Console.WriteLine(returned);

                    });

                    tasklist.Add(task);
                    task.Start();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            try
            {
                Task.WaitAll(tasklist.ToArray());
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            //produces two files with total counts for polkkeys and zipcodes
            MichelinCanadaPOLKCountsFileCondenser(polkfilefolderpath, deli);
            MichelinCanadaPOLKfsaCountsFileCondenser(fsafilefolderpath, deli); //by zip code file and by state code file.

        }

        static public Task<string> MichelinCanadaPOLKfsaDataReader(string file1, char deli1, char txtq, Dictionary<string, HashSet<string>> provincelookup)
        {
            string fsafilefolderpath = GetDesktopDirectory() + @"\michelin_canadapolk_counts\fsacounts";
            string polkfilefolderpath = GetDesktopDirectory() + @"\michelin_canadapolk_counts\polkcounts";

            string fsacountsfile = fsafilefolderpath + "\\" + GetFileNameWithoutExtension(file1) + "fsa_counts.txt"; // list of zips, appended with counts
            string polkcountsfile = polkfilefolderpath + "\\" + GetFileNameWithoutExtension(file1) + "polk_counts.txt";

            Dictionary<string, int> fsalist = new Dictionary<string, int>();
            Dictionary<string, int> polkkeysums = new Dictionary<string, int>();

            int rowcount = 0;

            using (StreamReader readfile = new StreamReader(file1))
            {
                // read and save header.
                string header = readfile.ReadLine();

                string line = string.Empty;
                while ((line = readfile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, deli1, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(deli1));
                    }

                    string[] splitline = splitlinebuilder.ToArray();
                    string fsa = splitline[0].Replace(txtq.ToString(), "");
                    string polk = splitline[1].Replace(txtq.ToString(), "");
                    int vehiclecount = Int32.Parse(splitline[2].Replace(txtq.ToString(), ""));

                    // ADD check for polk + zip combo. using a list made the process run for EVER!!!!! use a dict instead, or hashset.

                    if (!fsalist.ContainsKey(fsa))
                    {
                        fsalist.Add(fsa, vehiclecount);
                    }
                    else
                    {
                        fsalist[fsa] += vehiclecount;
                    }


                    if (!polkkeysums.ContainsKey(polk))
                    {
                        polkkeysums.Add(polk, vehiclecount);
                    }
                    else
                    {
                        polkkeysums[polk] += vehiclecount;
                    }

                    rowcount++;
                }
            }

            using (StreamWriter fsacountoutfile = new StreamWriter(fsacountsfile))
            {
                HashSet<string> fsawasfound = new HashSet<string>();

                fsacountoutfile.WriteLine("Province, FSA,VehicleCount");

                foreach (var province in provincelookup.Keys)
                {
                    foreach (var value in provincelookup[province])
                    {
                        foreach (var zip in fsalist.Keys)
                        {
                            if (value.Contains(zip))
                            {
                                fsawasfound.Add(zip);

                                List<string> linebuilder = new List<string>();
                                linebuilder.Add(province);
                                linebuilder.Add(zip);
                                linebuilder.Add(fsalist[zip].ToString());

                                fsacountoutfile.WriteLine(string.Join(deli1.ToString(), linebuilder.ToArray()));
                            }
                        }
                    }
                }

                foreach (var fsa in fsalist.Keys) //check for zips that where not matched to a state.
                {
                    if (!fsawasfound.Contains(fsa))
                    {
                        List<string> linebuilder = new List<string>();
                        linebuilder.Add("00"); // set artificial state code to 00. indicates zip was not found in state-zip lookup.
                        linebuilder.Add(fsa);
                        linebuilder.Add(fsalist[fsa].ToString());
                        fsacountoutfile.WriteLine(string.Join(deli1.ToString(), linebuilder.ToArray()));
                    }
                }
            }

            using (StreamWriter polkcountsoutfile = new StreamWriter(polkcountsfile))
            {
                polkcountsoutfile.WriteLine("Polkkey,VehicleCount");

                foreach (var polkkey in polkkeysums.Keys)
                {
                    List<string> linebuilder = new List<string>();
                    linebuilder.Add(polkkey);
                    linebuilder.Add(polkkeysums[polkkey].ToString());

                    polkcountsoutfile.WriteLine(string.Join(deli1.ToString(), linebuilder.ToArray()));
                }
            }

            string returnstring = rowcount.ToString();

            return Task.FromResult(returnstring);

        }

        static public void MichelinCanadaPOLKCountsFileCondenser(string polkdatadirectory, char deli)
        {
            //Console.Write("Drag and Drop Michelin Polk Count Data Files Folder here: ");
            //string polkdatadirectory = Console.ReadLine();
            string[] michelincanadapolkdatafilepaths = Directory.GetFiles(polkdatadirectory);
            //char deli = GetDelimiter();
            char txtq = '"';
            Console.WriteLine();

            string splitfilefolderpath = GetDesktopDirectory() + @"\michelin_canadapolk_counts\";
            string polkcountsfile = splitfilefolderpath + "\\" + "polk_counts.txt";

            Dictionary<string, int> canadapolkcounts = new Dictionary<string, int>();

            foreach (var file in michelincanadapolkdatafilepaths)
            {
                using (StreamReader polkcountfile = new StreamReader(file))
                {
                    polkcountfile.ReadLine();

                    string line = string.Empty;
                    while ((line = polkcountfile.ReadLine()) != null)
                    {
                        List<string> splitlinebuilder = new List<string>();
                        if (line.Contains(txtq))
                        {
                            splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, deli, txtq, false));
                        }
                        else
                        {
                            splitlinebuilder.AddRange(line.Split(deli));
                        }

                        string[] splitline = splitlinebuilder.ToArray();
                        string polkkey = splitline[0].Replace(txtq.ToString(), "");
                        int vehiclecount = Int32.Parse(splitline[1].Replace(txtq.ToString(), ""));

                        if (!canadapolkcounts.ContainsKey(polkkey))
                        {
                            canadapolkcounts.Add(polkkey, vehiclecount);
                        }
                        else
                        {
                            canadapolkcounts[polkkey] += vehiclecount;
                        }
                    }
                }
            }

            using (StreamWriter polkcountsoutfile = new StreamWriter(polkcountsfile))
            {
                var totalvehicles = canadapolkcounts.Sum(vehiclecount => vehiclecount.Value);

                polkcountsoutfile.WriteLine("Polkkey,VehicleCount - {0}", totalvehicles);

                foreach (var polkkey in canadapolkcounts.Keys)
                {
                    List<string> linebuilder = new List<string>();
                    linebuilder.Add(polkkey);
                    linebuilder.Add(canadapolkcounts[polkkey].ToString());

                    polkcountsoutfile.WriteLine(string.Join(deli.ToString(), linebuilder.ToArray()));
                }
            }
        }

        static public void MichelinCanadaPOLKfsaCountsFileCondenser(string fsadatadirectory, char deli)
        {
            //Console.Write("Drag and Drop Michelin Zip Count Data Files Folder here: ");
            //string zipdatadirectory = Console.ReadLine();
            string[] michelinfsadatafilepaths = Directory.GetFiles(fsadatadirectory);
            //char deli = GetDelimiter();
            char txtq = '"';
            Console.WriteLine();

            string splitfilefolderpath = GetDesktopDirectory() + @"\michelin_canadapolk_counts\";
            string fsacountsfile = splitfilefolderpath + "\\" + "fsa_counts.txt";
            string provincecountsfile = splitfilefolderpath + "\\" + "province_counts.txt";

            // state key, zipcode key, vehicle count
            Dictionary<string, Dictionary<string, int>> canadafsacounts = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> canadaprovincecounts = new Dictionary<string, int>();

            foreach (var file in michelinfsadatafilepaths)
            {
                using (StreamReader fsacountfile = new StreamReader(file))
                {
                    fsacountfile.ReadLine(); //read headers.

                    string line = string.Empty;
                    while ((line = fsacountfile.ReadLine()) != null)
                    {
                        List<string> splitlinebuilder = new List<string>();
                        if (line.Contains(txtq))
                        {
                            splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, deli, txtq, false));
                        }
                        else
                        {
                            splitlinebuilder.AddRange(line.Split(deli));
                        }

                        string[] splitline = splitlinebuilder.ToArray();
                        string provincecode = splitline[0].Replace(txtq.ToString(), "");
                        string fsa = splitline[1].Replace(txtq.ToString(), "");
                        int vehiclecount = Int32.Parse(splitline[2].Replace(txtq.ToString(), ""));

                        if (!canadafsacounts.ContainsKey(provincecode)) // if the state dictionary does not have the state.
                        {
                            Dictionary<string, int> tempdict = new Dictionary<string, int>();
                            tempdict.Add(fsa, vehiclecount); // zip code and vehicle count new state line saved to temp dict. copied into uslevel dict.
                            canadafsacounts.Add(provincecode, tempdict);
                        }
                        else
                        {
                            if (!canadafsacounts[provincecode].ContainsKey(fsa)) //if the nested dictionary doesnt contain the zip.
                            {
                                canadafsacounts[provincecode].Add(fsa, vehiclecount);
                            }
                            else
                            {
                                canadafsacounts[provincecode][fsa] += vehiclecount; //if the zipcode is already in the us level dict. add to vehicle count.
                            }
                        }

                        if (!canadaprovincecounts.ContainsKey(provincecode))
                        {
                            canadaprovincecounts.Add(provincecode, vehiclecount);
                        }
                        else
                        {
                            canadaprovincecounts[provincecode] += vehiclecount;
                        }
                    }
                }
            }

            using (StreamWriter fsacountsoutfile = new StreamWriter(fsacountsfile))
            {
                long totalvehiclecount = 0;

                foreach (var province in canadafsacounts.Keys)
                {
                    Dictionary<string, int> tempdict = canadafsacounts[province];

                    totalvehiclecount += tempdict.Sum(vehiclecount => vehiclecount.Value);
                }

                fsacountsoutfile.WriteLine("ProvinceCode,FSACode,VehicleCount - {0}", totalvehiclecount);

                foreach (var provincecode in canadafsacounts.Keys)
                {
                    foreach (var fsa in canadafsacounts[provincecode].Keys)
                    {
                        List<string> linebuilder = new List<string>();
                        linebuilder.Add(provincecode);
                        linebuilder.Add(fsa);
                        linebuilder.Add(canadafsacounts[provincecode][fsa].ToString());

                        fsacountsoutfile.WriteLine(string.Join(deli.ToString(), linebuilder.ToArray()));
                    }
                }
            }

            using (StreamWriter provincecountsoutfile = new StreamWriter(provincecountsfile)) // unsorted output. can sort using hash or list of the keys, output based on that.
            {
                provincecountsoutfile.WriteLine("ProvinceCode,VehicleCount");
                foreach (var province in canadaprovincecounts.Keys)
                {
                    List<string> linebuilder = new List<string>();
                    linebuilder.Add(province);
                    linebuilder.Add(canadaprovincecounts[province].ToString());

                    provincecountsoutfile.WriteLine(string.Join(deli.ToString(), linebuilder.ToArray()));
                }
            }
        }

        static public void MichelinCanadaPOLKNewfsaFinder() //look for added or dropped fsas.
        {
            // use previously created fsa counts files.

            Console.WriteLine("-Enter Current Year FSA Counts file-");
            string currentyearfile = GetAFile();
            char currentyeardeli = GetDelimiter();
            Console.WriteLine();

            Console.WriteLine("-Enter Last Year FSA Counts file-");
            string lasatyearfile = GetAFile();
            char lastyeardeli = GetDelimiter();
            Console.WriteLine();

            char txtq = '"';
            string splitfilefolderpath = GetDesktopDirectory() + @"\michelin_canadapolk_counts";
            if (!Directory.Exists(splitfilefolderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(splitfilefolderpath);
            }

            string newfsalist = splitfilefolderpath + "\\" + GetFileNameWithoutExtension(currentyearfile) + "_newfsas.txt";
            string droppedfsalist = splitfilefolderpath + "\\" + GetFileNameWithoutExtension(currentyearfile) + "_drops.txt";

            HashSet<string> newfsas = new HashSet<string>();
            HashSet<string> droppedfsas = new HashSet<string>();

            HashSet<string> currentuniquefsas = new HashSet<string>();
            HashSet<string> lastuniquefsas = new HashSet<string>();
            int currentuniquecounter = 0;
            int lastuniquecounter = 0;
            string header = string.Empty;

            using (StreamReader currentfile = new StreamReader(currentyearfile))
            {
                header = currentfile.ReadLine(); // header read

                //add check to find the zip_code column.

                string line = string.Empty;
                while ((line = currentfile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();

                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, currentyeardeli, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(currentyeardeli));
                    }

                    string[] splitline = splitlinebuilder.ToArray();
                    int geoidindex = 1; // add checks for if contains txtqs requires rewrite of alot of methods.

                    currentuniquefsas.Add(splitline[geoidindex]);

                    currentuniquecounter = currentuniquefsas.Count;
                }
            }

            using (StreamReader lastfile = new StreamReader(lasatyearfile))
            {
                lastfile.ReadLine(); // header read

                //add check to find the zip_code column.

                string line = string.Empty;
                while ((line = lastfile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();

                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, currentyeardeli, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(currentyeardeli));
                    }

                    string[] splitline = splitlinebuilder.ToArray();
                    int geoidindex = 1; // add checks for if contains txtqs requires rewrite of alot of methods.

                    lastuniquefsas.Add(splitline[geoidindex]);

                    lastuniquecounter = lastuniquefsas.Count;
                }
            }

            foreach (var fsa in currentuniquefsas)
            {
                if (!lastuniquefsas.Contains(fsa))
                {
                    newfsas.Add(fsa);
                }
            }

            foreach (var fsa in lastuniquefsas)
            {
                if (!currentuniquefsas.Contains(fsa))
                {
                    droppedfsas.Add(fsa);
                }
            }

            using (StreamWriter newfsasfile = new StreamWriter(newfsalist))
            {
                List<string> splitlinebuilder = new List<string>();

                if (header.Contains(txtq))
                {
                    splitlinebuilder.AddRange(SplitLineWithTxtQualifier(header, currentyeardeli, txtq, false));
                }
                else
                {
                    splitlinebuilder.AddRange(header.Split(currentyeardeli));
                }

                string[] splitheader = splitlinebuilder.ToArray();
                string geoname = splitheader[1].Trim();
                newfsasfile.WriteLine("{0}", geoname); //header

                foreach (var fsa in newfsas)
                {
                    newfsasfile.WriteLine(fsa);
                }
            }

            using (StreamWriter droppedfsasfile = new StreamWriter(droppedfsalist))
            {
                List<string> splitlinebuilder = new List<string>();

                if (header.Contains(txtq))
                {
                    splitlinebuilder.AddRange(SplitLineWithTxtQualifier(header, currentyeardeli, txtq, false));
                }
                else
                {
                    splitlinebuilder.AddRange(header.Split(currentyeardeli));
                }

                string[] splitheader = splitlinebuilder.ToArray();
                string geoname = splitheader[1].Trim();
                droppedfsasfile.WriteLine("{0}", geoname); //header

                foreach (var fsa in droppedfsas)
                {
                    droppedfsasfile.WriteLine(fsa);
                }
            }
        }

        static public void MichelinCanadaPOLKfsaCountsDiffReader()
        {
            Console.WriteLine("-Enter Current Year fsa Counts file-");
            string currentyearfile = GetAFile();
            char currentyeardeli = GetDelimiter();
            Console.WriteLine();

            Console.WriteLine("-Enter Last Year fsa Counts file-");
            string lasatyearfile = GetAFile();
            char lastyeardeli = GetDelimiter();
            Console.WriteLine();

            //Console.Write("Current Vintage Year: ");
            //string currentyear = Console.ReadLine().Trim();

            char txtq = '"';

            string filefolderpath = GetDesktopDirectory() + @"\michelin_canadapolk_counts";
            if (!Directory.Exists(filefolderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(filefolderpath);
            }

            string percentdifffile = filefolderpath + "\\" + GetFileNameWithoutExtension(currentyearfile) + "_difs.csv";

            //Dictionary<string, int> currentyeardata = new Dictionary<string, int>();
            Dictionary<string, Dictionary<string, int>> currentyeardata = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, Dictionary<string, int>> lastyeardata = new Dictionary<string, Dictionary<string, int>>();

            using (StreamReader currentfile = new StreamReader(currentyearfile))
            {
                string currentheader = currentfile.ReadLine(); // read header

                string line = string.Empty;

                while ((line = currentfile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, currentyeardeli, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(currentyeardeli));
                    }

                    string[] splitline = splitlinebuilder.ToArray();

                    string provincecode = splitline[0].Replace(txtq.ToString(), "");
                    string fsa = splitline[1].Replace(txtq.ToString(), "");
                    int vehiclecount = Int32.Parse(splitline[2].Replace(txtq.ToString(), ""));


                    if (!currentyeardata.ContainsKey(provincecode)) // if the state dictionary does not have the state.
                    {
                        Dictionary<string, int> tempdict = new Dictionary<string, int>();
                        tempdict.Add(fsa, vehiclecount); // zip code and vehicle count new state line saved to temp dict. copied into uslevel dict.
                        currentyeardata.Add(provincecode, tempdict);
                    }
                    else
                    {
                        if (!currentyeardata[provincecode].ContainsKey(fsa)) //if the nested dictionary doesnt contain the zip.
                        {
                            currentyeardata[provincecode].Add(fsa, vehiclecount);
                        }
                        else
                        {
                            currentyeardata[provincecode][fsa] += vehiclecount; //if the zipcode is already in the us level dict. add to vehicle count.
                        }
                    }
                }
            }

            using (StreamReader lastfile = new StreamReader(lasatyearfile))
            {
                string lastheader = lastfile.ReadLine(); // read header

                string line = string.Empty;

                while ((line = lastfile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, currentyeardeli, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(currentyeardeli));
                    }

                    string[] splitline = splitlinebuilder.ToArray();

                    string provincecode = splitline[0].Replace(txtq.ToString(), "");
                    string fsa = splitline[1].Replace(txtq.ToString(), "");
                    int vehiclecount = Int32.Parse(splitline[2].Replace(txtq.ToString(), ""));


                    if (!lastyeardata.ContainsKey(provincecode)) // if the state dictionary does not have the state.
                    {
                        Dictionary<string, int> tempdict = new Dictionary<string, int>();
                        tempdict.Add(fsa, vehiclecount); // zip code and vehicle count new state line saved to temp dict. copied into uslevel dict.
                        lastyeardata.Add(provincecode, tempdict);
                    }
                    else
                    {
                        if (!lastyeardata[provincecode].ContainsKey(fsa)) //if the nested dictionary doesnt contain the zip.
                        {
                            lastyeardata[provincecode].Add(fsa, vehiclecount);
                        }
                        else
                        {
                            lastyeardata[provincecode][fsa] += vehiclecount; //if the zipcode is already in the us level dict. add to vehicle count.
                        }
                    }
                }
            }

            using (StreamWriter percentdiffoutfile = new StreamWriter(percentdifffile))
            {
                percentdiffoutfile.WriteLine("ProvinceCode, FSACode, LastYearVehicleCount, CurrentyearVehicleCount, %Diff");

                foreach (var province in currentyeardata.Keys)
                {
                    foreach (var fsa in currentyeardata[province].Keys)
                    {
                        if (lastyeardata.ContainsKey(province))
                        {
                            if (lastyeardata[province].ContainsKey(fsa))
                            {
                                double percentdiff = 0;

                                if (lastyeardata[province][fsa] != 0)
                                {
                                    // [(V2-V1) / |V1|) *100] (V1 = last year value, V2 = current year value)
                                    double currentvalue = currentyeardata[province][fsa];
                                    double lastvalue = lastyeardata[province][fsa];

                                    percentdiff = ((currentvalue - lastvalue) / Math.Abs(lastvalue)) * 100;
                                }
                                else
                                {
                                    percentdiff = currentyeardata[province][fsa] * 100;
                                }

                                List<string> linebuilder = new List<string>();
                                linebuilder.Add(province); // state
                                linebuilder.Add(fsa); // zip
                                linebuilder.Add(lastyeardata[province][fsa].ToString());
                                linebuilder.Add(currentyeardata[province][fsa].ToString());
                                linebuilder.Add(percentdiff.ToString() + "%");

                                percentdiffoutfile.WriteLine(string.Join(currentyeardeli.ToString(), linebuilder.ToArray()));
                            }
                        }
                    }
                }
            }
        }

        static public void MichelinCanadaPOLKPolkKeyCountsDiffReader() //mirror code of us method
        {
            Console.WriteLine("-Enter Current Year PolkKey Counts file-");
            string currentyearfile = GetAFile();
            char currentyeardeli = GetDelimiter();
            Console.WriteLine();

            Console.WriteLine("-Enter Last Year PolkKey Counts file-");
            string lasatyearfile = GetAFile();
            char lastyeardeli = GetDelimiter();
            Console.WriteLine();

            char txtq = '"';

            string filefolderpath = GetDesktopDirectory() + @"\michelin_canadapolk_counts";
            if (!Directory.Exists(filefolderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(filefolderpath);
            }

            string percentdifffile = filefolderpath + "\\" + GetFileNameWithoutExtension(currentyearfile) + "_difs.csv";

            Dictionary<string, int> currentyeardata = new Dictionary<string, int>();
            Dictionary<string, int> lastyeardata = new Dictionary<string, int>();

            using (StreamReader currentfile = new StreamReader(currentyearfile))
            {
                string currentheader = currentfile.ReadLine(); // read header

                string line = string.Empty;

                while ((line = currentfile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, currentyeardeli, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(currentyeardeli));
                    }

                    string[] splitline = splitlinebuilder.ToArray();

                    string polkkey = splitline[0].Replace(txtq.ToString(), "");
                    int vehiclecount = Int32.Parse(splitline[1].Replace(txtq.ToString(), ""));

                    if (!currentyeardata.ContainsKey(polkkey)) //if the nested dictionary doesnt contain the zip.
                    {
                        currentyeardata.Add(polkkey, vehiclecount);
                    }
                    else
                    {
                        currentyeardata[polkkey] += vehiclecount; //if the zipcode is already in the us level dict. add to vehicle count.
                    }
                }
            }

            using (StreamReader lastfile = new StreamReader(lasatyearfile))
            {
                string currentheader = lastfile.ReadLine(); // read header

                string line = string.Empty;

                while ((line = lastfile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, currentyeardeli, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(currentyeardeli));
                    }

                    string[] splitline = splitlinebuilder.ToArray();

                    string polkkey = splitline[0].Replace(txtq.ToString(), "");
                    int vehiclecount = Int32.Parse(splitline[1].Replace(txtq.ToString(), ""));

                    if (!lastyeardata.ContainsKey(polkkey)) //if the nested dictionary doesnt contain the zip.
                    {
                        lastyeardata.Add(polkkey, vehiclecount);
                    }
                    else
                    {
                        lastyeardata[polkkey] += vehiclecount; //if the zipcode is already in the us level dict. add to vehicle count.
                    }
                }
            }

            using (StreamWriter percentdiffoutfile = new StreamWriter(percentdifffile))
            {
                percentdiffoutfile.WriteLine("PolkKey, LastYearVehicleCount, CurrentyearVehicleCount, %Diff");

                foreach (var polkkey in currentyeardata.Keys)
                {
                    if (lastyeardata.ContainsKey(polkkey))
                    {
                        double percentdiff = 0;

                        if (lastyeardata[polkkey] != 0)
                        {
                            // [(V2-V1) / |V1|) *100] (V1 = last year value, V2 = current year value)
                            double currentvalue = currentyeardata[polkkey];
                            double lastvalue = lastyeardata[polkkey];

                            percentdiff = ((currentvalue - lastvalue) / Math.Abs(lastvalue)) * 100;
                        }
                        else
                        {
                            percentdiff = currentyeardata[polkkey] * 100;
                        }

                        List<string> linebuilder = new List<string>();
                        linebuilder.Add(polkkey); // state
                        linebuilder.Add(lastyeardata[polkkey].ToString());
                        linebuilder.Add(currentyeardata[polkkey].ToString());
                        linebuilder.Add(percentdiff.ToString() + "%");

                        percentdiffoutfile.WriteLine(string.Join(currentyeardeli.ToString(), linebuilder.ToArray()));
                    }
                }
            }
        }

        static public void MichelinCanadaPOLKProvinceCountsDiffReader() // same code as MIchelinCanadaPolkKeyCountsDiffReader() just uses province names instead of polk key.
        {
            Console.WriteLine("-Enter Current Year Province Counts file-");
            string currentyearfile = GetAFile();
            char currentyeardeli = GetDelimiter();
            Console.WriteLine();

            Console.WriteLine("-Enter Last Year Province Counts file-");
            string lasatyearfile = GetAFile();
            char lastyeardeli = GetDelimiter();
            Console.WriteLine();

            //Console.Write("Current Vintage Year: ");
            //string currentyear = Console.ReadLine().Trim();

            char txtq = '"';

            string filefolderpath = GetDesktopDirectory() + @"\michelin_canadapolk_counts";
            if (!Directory.Exists(filefolderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(filefolderpath);
            }

            string percentdifffile = filefolderpath + "\\" + GetFileNameWithoutExtension(currentyearfile) + "_difs.csv";

            Dictionary<string, int> currentyeardata = new Dictionary<string, int>();
            Dictionary<string, int> lastyeardata = new Dictionary<string, int>();

            using (StreamReader currentfile = new StreamReader(currentyearfile))
            {
                string currentheader = currentfile.ReadLine(); // read header

                string line = string.Empty;

                while ((line = currentfile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, currentyeardeli, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(currentyeardeli));
                    }

                    string[] splitline = splitlinebuilder.ToArray();

                    string provincecode = splitline[0].Replace(txtq.ToString(), "");
                    int vehiclecount = Int32.Parse(splitline[1].Replace(txtq.ToString(), ""));

                    if (!currentyeardata.ContainsKey(provincecode)) //if the nested dictionary doesnt contain the zip.
                    {
                        currentyeardata.Add(provincecode, vehiclecount);
                    }
                    else
                    {
                        currentyeardata[provincecode] += vehiclecount;
                    }
                }
            }

            using (StreamReader lastfile = new StreamReader(lasatyearfile))
            {
                string currentheader = lastfile.ReadLine(); // read header

                string line = string.Empty;

                while ((line = lastfile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, currentyeardeli, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(currentyeardeli));
                    }

                    string[] splitline = splitlinebuilder.ToArray();

                    string provincecode = splitline[0].Replace(txtq.ToString(), "");
                    int vehiclecount = Int32.Parse(splitline[1].Replace(txtq.ToString(), ""));

                    if (!lastyeardata.ContainsKey(provincecode)) //if the nested dictionary doesnt contain the zip.
                    {
                        lastyeardata.Add(provincecode, vehiclecount);
                    }
                    else
                    {
                        lastyeardata[provincecode] += vehiclecount; //if the zipcode is already in the us level dict. add to vehicle count.
                    }
                }
            }

            using (StreamWriter percentdiffoutfile = new StreamWriter(percentdifffile))
            {
                percentdiffoutfile.WriteLine("ProvinceCode, LastYearVehicleCount, CurrentyearVehicleCount, %Diff");

                foreach (var provincecode in currentyeardata.Keys)
                {
                    if (lastyeardata.ContainsKey(provincecode))
                    {
                        double percentdiff = 0;

                        if (lastyeardata[provincecode] != 0)
                        {
                            // [(V2-V1) / |V1|) *100] (V1 = last year value, V2 = current year value)
                            double currentvalue = currentyeardata[provincecode];
                            double lastvalue = lastyeardata[provincecode];

                            percentdiff = ((currentvalue - lastvalue) / Math.Abs(lastvalue)) * 100;
                        }
                        else
                        {
                            percentdiff = currentyeardata[provincecode] * 100;
                        }

                        List<string> linebuilder = new List<string>();
                        linebuilder.Add(provincecode); // state
                        linebuilder.Add(lastyeardata[provincecode].ToString());
                        linebuilder.Add(currentyeardata[provincecode].ToString());
                        linebuilder.Add(percentdiff.ToString() + "%");

                        percentdiffoutfile.WriteLine(string.Join(currentyeardeli.ToString(), linebuilder.ToArray()));
                    }
                }
            }
        }

        // other qa tasks.
        static public void MichelinCanadaPOLKVehicleInfoFileCleaner() // clean the new vehicle file first
        {
            // expected header: POLK_KEY,YEAR_MODEL,MAKE_NAME,MODEL_NAME,TRIM_NAME,SEGMENT_NAME

            // add check for 'blanks' -> change blanks to 'N/A'
            Console.WriteLine("-Enter Current Year Vehicle Data file-");
            string file = GetAFile();
            char deli = GetDelimiter();
            char txtq = GetTXTQualifier();
            Console.WriteLine();

            string filefolderpath = GetDesktopDirectory() + @"\michelin_canadapolk_counts";
            if (!Directory.Exists(filefolderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(filefolderpath);
            }

            string cleanedfile = filefolderpath + "\\" + GetFileNameWithoutExtension(file) + "cleaned.txt";

            using (StreamReader vehiclecountsfile = new StreamReader(file))
            {
                using (StreamWriter cleanedvehiclefile = new StreamWriter(cleanedfile))
                {
                    string header = vehiclecountsfile.ReadLine();
                    cleanedvehiclefile.WriteLine(header);
                    List<string> headersplitbuilder = new List<string>();

                    if (header.Contains(txtq))
                    {
                        headersplitbuilder.AddRange(SplitLineWithTxtQualifier(header, deli, txtq, false));
                    }
                    else
                    {
                        headersplitbuilder.AddRange(header.Split(deli));
                    }

                    string year = "YEAR_MODEL"; // find the index of this column. hard coded for now.

                    int yearindex = headersplitbuilder.IndexOf(year); // trying out new method. shorter.

                    string line = string.Empty;
                    int counter = 0;
                    while ((line = vehiclecountsfile.ReadLine()) != null)
                    {
                        List<string> splitlinebuilder = new List<string>();
                        if (line.Contains(txtq))
                        {
                            splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, deli, txtq, false));
                        }
                        else
                        {
                            splitlinebuilder.AddRange(line.Split(deli));
                        }

                        string[] splitline = splitlinebuilder.ToArray();

                        if (splitline[yearindex].ToCharArray().Count() != 4)
                        {
                            splitline[yearindex] = "0001";
                            counter++;
                        }

                        cleanedvehiclefile.WriteLine(string.Join(deli.ToString(), splitline));
                    }

                    Console.WriteLine();
                    Console.WriteLine("Records changed - {0}", counter);
                }
            }
        }

        static public void MichelinCanadaPOLKMichelintoPolkCrossWalk() // do the vehicle file crosswalk (mirror code of us)
        {
            // uses vehicle data file from polk and the 
            // e1platform tables (make, model, year, trim) should match
            //    stage_polk_lookup -> michelin_vehicle_data_201810.csv (from polk)
            //
            //    mich_polk_lookup -> 2019 US Polk Summary Final - Nuestar.csv (from michelin)   

            //check the unique (make, model, year, trim) from each new file against eachother
            // check the unique (make, model, year, trim) from new to old data????? 


            // stage_polk_lookup -> michelin_vehicle_data_201810.csv
            Console.WriteLine("- Enter Polk Vehicle Count File -");
            string polkdatafile = GetAFile();
            char polkdeli = GetDelimiter();

            Console.WriteLine("- Enter Michelin Vehicle Count File -");
            string michelindatafile = GetAFile();
            char michelindeli = GetDelimiter();

            char txtq = GetTXTQualifier(); // "

            Console.Write("Current Vintage Year: ");
            string currentyear = Console.ReadLine().Trim();

            Dictionary<string, int> polkvehicledata = new Dictionary<string, int>(); //concatenated (make, model, year, trim) will be the string, count of will be int.
            Dictionary<string, int> michelinvehicledata = new Dictionary<string, int>(); // concatenated (make, model, year, trim) will be the string, count of will be int.

            Dictionary<string, List<string>> polkvehiclenames = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> michelinvehiclenames = new Dictionary<string, List<string>>();

            string filefolderpath = GetDesktopDirectory() + @"\michelin_canadapolk_counts";
            if (!Directory.Exists(filefolderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(filefolderpath);
            }

            string vehicleinfofile = filefolderpath + "\\" + currentyear + "_vehicleinfo.csv";

            using (StreamReader readpolkfile = new StreamReader(polkdatafile))
            {
                string header = readpolkfile.ReadLine();

                //add check to verify that the columns are in the same position.... hard coding for now.
                // need to have the whole header in order to print out and verify on screen.

                string year = "YEAR_MODEL";
                string make = "MAKE_NAME";
                string model = "MODEL_NAME";
                string trim = "TRIM_NAME";

                int yearindex = ColumnIndex(header, polkdeli, year);
                int makeindex = ColumnIndex(header, polkdeli, make);
                int modelindex = ColumnIndex(header, polkdeli, model);
                int trimindex = ColumnIndex(header, polkdeli, trim);

                string line = string.Empty;
                int linecount = 0;
                while ((line = readpolkfile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, polkdeli, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(polkdeli));
                    }

                    string[] splitline = splitlinebuilder.ToArray();

                    string concateddictkey = splitline[yearindex] + splitline[makeindex] + splitline[modelindex] + splitline[trimindex];

                    List<string> vehiclenameinfo = new List<string>();
                    vehiclenameinfo.Add(splitline[yearindex]);
                    vehiclenameinfo.Add(splitline[makeindex]);
                    vehiclenameinfo.Add(splitline[modelindex]);
                    vehiclenameinfo.Add(splitline[trimindex]);


                    if (!polkvehicledata.ContainsKey(concateddictkey))
                    {
                        polkvehicledata.Add(concateddictkey, 1);
                    }
                    else
                    {
                        polkvehicledata[concateddictkey] += 1;
                    }

                    if (!polkvehiclenames.ContainsKey(concateddictkey))
                    {
                        polkvehiclenames.Add(concateddictkey, vehiclenameinfo);
                    }

                    linecount++;
                }

                Console.WriteLine("{0} - record count - {1}", polkdatafile, linecount);
            }

            using (StreamReader readmichelindatafile = new StreamReader(michelindatafile))
            {
                string header = readmichelindatafile.ReadLine();
                //add check to verify that the columns are in the same position.... hard coding for now.
                // need to have the whole header in order to print out and verify on screen.

                string year = "YEAR_MODEL";
                string make = "MAKE_NAME";
                string model = "MODEL_NAME";
                string trim = "TRIM_NAME";

                int yearindex = ColumnIndex(header, polkdeli, year);
                int makeindex = ColumnIndex(header, polkdeli, make);
                int modelindex = ColumnIndex(header, polkdeli, model);
                int trimindex = ColumnIndex(header, polkdeli, trim);

                string line = string.Empty;
                int linecount = 0;
                while ((line = readmichelindatafile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, michelindeli, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(michelindeli));
                    }

                    string[] splitline = splitlinebuilder.ToArray();

                    string concateddictkey = splitline[yearindex] + splitline[makeindex] + splitline[modelindex] + splitline[trimindex];

                    List<string> vehiclenameinfo = new List<string>();
                    vehiclenameinfo.Add(splitline[yearindex]);
                    vehiclenameinfo.Add(splitline[makeindex]);
                    vehiclenameinfo.Add(splitline[modelindex]);
                    vehiclenameinfo.Add(splitline[trimindex]);

                    if (!michelinvehicledata.ContainsKey(concateddictkey))
                    {
                        michelinvehicledata.Add(concateddictkey, 1);
                    }
                    else
                    {
                        michelinvehicledata[concateddictkey] += 1;
                    }

                    if (!michelinvehiclenames.ContainsKey(concateddictkey))
                    {
                        michelinvehiclenames.Add(concateddictkey, vehiclenameinfo);
                    }

                    linecount++;
                }

                Console.WriteLine("{0} - record count - {1}", michelindatafile, linecount);
            }

            Dictionary<string, List<string>> michelinonly = new Dictionary<string, List<string>>();

            using (StreamWriter vehicleinfooutfile = new StreamWriter(vehicleinfofile))
            {
                List<string> headerlinebuilder = new List<string>();
                headerlinebuilder.Add("VehicleInfo");
                headerlinebuilder.Add("Count");
                headerlinebuilder.Add("SingleSource");
                headerlinebuilder.Add("PolkTrim");
                headerlinebuilder.Add("MichelinTrim");

                vehicleinfooutfile.WriteLine(string.Join(polkdeli.ToString(), headerlinebuilder.ToArray()));

                //Dictionary<string, int> tempdict = new Dictionary<string, int>();

                foreach (var vehicle in polkvehicledata.Keys)
                {
                    if (michelinvehicledata.ContainsKey(vehicle))
                    {
                        List<string> linebuilder = new List<string>();
                        linebuilder.Add(vehicle);
                        linebuilder.Add(polkvehicledata[vehicle].ToString());
                        linebuilder.Add("both");
                        linebuilder.Add("");
                        linebuilder.Add("");

                        vehicleinfooutfile.WriteLine(string.Join(polkdeli.ToString(), linebuilder.ToArray()));

                        //tempdict.Add(vehicle, polkvehicledata[vehicle]); //found
                    }
                    else
                    {
                        List<string> linebuilder = new List<string>();
                        linebuilder.Add(vehicle);
                        linebuilder.Add(polkvehicledata[vehicle].ToString());
                        linebuilder.Add("polkonly");
                        linebuilder.Add("");
                        linebuilder.Add("");

                        vehicleinfooutfile.WriteLine(string.Join(polkdeli.ToString(), linebuilder.ToArray()));
                    }
                }

                foreach (var vehicle in michelinvehicledata.Keys)
                {

                    if (!polkvehicledata.ContainsKey(vehicle))
                    {
                        List<string> tempmichelinname = michelinvehiclenames[vehicle];

                        bool found = false;

                        foreach (var polkvehicle in polkvehiclenames.Keys) // loop through the name list dict. compare list values. if at least 3 values match output.
                        {
                            List<string> temppolkname = polkvehiclenames[polkvehicle];

                            int year = 0; // all are previously found. add code to save the list indexes when they are added to the lsits.
                            int make = 1;
                            int model = 2;
                            int trim = 3;

                            if (temppolkname[year] == temppolkname[year] && temppolkname[make] == temppolkname[make] && temppolkname[model] == temppolkname[model])
                            {
                                if (temppolkname[trim] != temppolkname[trim])
                                {
                                    found = true;
                                    List<string> linebuilder = new List<string>();
                                    linebuilder.Add(vehicle);
                                    linebuilder.Add(michelinvehicledata[vehicle].ToString());
                                    linebuilder.Add("michelinonly");
                                    linebuilder.Add(temppolkname[trim]);
                                    linebuilder.Add(tempmichelinname[trim]);

                                    vehicleinfooutfile.WriteLine(string.Join(polkdeli.ToString(), linebuilder.ToArray()));
                                }
                            }
                        }

                        if (found == false)
                        {
                            michelinonly.Add(vehicle, tempmichelinname);

                            List<string> linebuilder = new List<string>();
                            linebuilder.Add(vehicle);
                            linebuilder.Add(michelinvehicledata[vehicle].ToString());
                            linebuilder.Add("michelinonly");
                            linebuilder.Add("");
                            linebuilder.Add("");

                            vehicleinfooutfile.WriteLine(string.Join(polkdeli.ToString(), linebuilder.ToArray()));
                        }
                    }
                }
            }

            string michelinonlyfile = filefolderpath + "\\michelinonly-vehicles.csv";
            using (StreamWriter michelinonlyoutfile = new StreamWriter(michelinonlyfile))
            {
                List<string> headerlinebuilder = new List<string>();
                headerlinebuilder.Add("VehicleInfo");
                headerlinebuilder.Add("Year");
                headerlinebuilder.Add("Make");
                headerlinebuilder.Add("Model");
                headerlinebuilder.Add("Trim");

                michelinonlyoutfile.WriteLine(string.Join(polkdeli.ToString(), headerlinebuilder.ToArray()));

                foreach (var vehicle in michelinonly.Keys)
                {
                    List<string> linebuilder = new List<string>();
                    linebuilder.Add(vehicle);

                    foreach (var value in michelinonly[vehicle])
                    {
                        linebuilder.Add(value);
                    }

                    michelinonlyoutfile.WriteLine(string.Join(polkdeli.ToString(), linebuilder.ToArray()));
                }
            }

            int polkunique = polkvehicledata.Count;
            int michelinunique = michelinvehicledata.Count;

            Console.WriteLine();
            Console.WriteLine("{0} - Polk Unique Vehicles", polkunique);
            Console.WriteLine("{0} - Michelin Unique Vehicles", michelinunique);

        }

        static public void MichelinCanadaPOLKTirePotentialSegmentChecker() // check the TP_SEG columns 
        {
            // e1platform mich_polk_lookup table tp_seg column should match us_usage_table table tp_seg column

            // mich_polk_lookup table is updated with the "2019 US Polk Summary Final - Nuestar.csv" file from michelin.

            // us_usage_table table is updated with the "2019 US Usage-v1.csv" file from michelin.

            // TP_SEG is Group_Cat and Standard_Tire_Size concatenated 


            // Each TP_SEG entry in the US Usage file should be unique...
            // Compare uniques from both files. 
            // Output a file with two columns, matching ... US-Usage-TPseg , Summary-File-TPSEG
            // non-matches are listed as "tpseg" , "no match" in appropriate columns

            Console.WriteLine("-Enter Canada Usage File-");
            string canadausagefile = GetAFile();
            char canadausagedeli = GetDelimiter();
            char txtq = GetTXTQualifier();

            Console.WriteLine();
            Console.WriteLine("-Enter Canada Summary File-");
            string canadasummaryfile = GetAFile();
            char canadasummarydeli = GetDelimiter();
            // char txtq = GetTXTQualifier();

            string filefolderpath = GetDesktopDirectory() + @"\michelin_canadapolk_counts";
            if (!Directory.Exists(filefolderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(filefolderpath);
            }

            string tpsegfile = filefolderpath + "\\tpsegments.txt";
            char newdeli = '\t'; // tab

            HashSet<string> canadausagetpsegs = new HashSet<string>();
            HashSet<string> canadasummarytpsegs = new HashSet<string>();

            int matches = 0;
            int canadasummaryrecords = 0;
            int canadausagerecords = 0;

            using (StreamReader canadausagereadfile = new StreamReader(canadausagefile))
            {
                string header = canadausagereadfile.ReadLine();

                string tpsegname = "TP_SEG"; //column index finder puts everything .toupper().

                //Int32 tpsegindex; //system.int32
                int tpsegindex = 0; // primative data type. does not allow for null values.

                try
                {
                    tpsegindex = ColumnIndexWithQualifier(header, canadausagedeli, txtq, tpsegname);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }

                string line = string.Empty;
                while ((line = canadausagereadfile.ReadLine()) != null)
                {
                    List<string> arraybuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        arraybuilder.AddRange(SplitLineWithTxtQualifier(line, canadausagedeli, txtq, false));
                    }
                    else
                    {
                        arraybuilder.AddRange(line.Split(canadausagedeli));
                    }

                    string[] splitline = arraybuilder.ToArray();
                    bool added = canadausagetpsegs.Add(splitline[tpsegindex]);

                    if (added == true)
                    {
                        canadausagerecords++;
                    }
                }
            }

            using (StreamReader ussummaryreadfile = new StreamReader(canadasummaryfile))
            {
                string header = ussummaryreadfile.ReadLine();

                string tpsegname = "TP_SEG"; //column index finder puts everything .toupper().

                //Int32 tpsegindex; //system.int32
                int tpsegindex = 0; // primative data type. does not allow for null values.

                try
                {
                    tpsegindex = ColumnIndexWithQualifier(header, canadausagedeli, txtq, tpsegname);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }

                string line = string.Empty;
                while ((line = ussummaryreadfile.ReadLine()) != null)
                {
                    List<string> arraybuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        arraybuilder.AddRange(SplitLineWithTxtQualifier(line, canadausagedeli, txtq, false));
                    }
                    else
                    {
                        arraybuilder.AddRange(line.Split(canadausagedeli));
                    }

                    string[] splitline = arraybuilder.ToArray();
                    bool added = canadasummarytpsegs.Add(splitline[tpsegindex]);

                    if (added == true)
                    {
                        canadasummaryrecords++;
                    }
                }
            }


            using (StreamWriter tpsegoutfile = new StreamWriter(tpsegfile))
            {
                tpsegoutfile.WriteLine("{0}{1}{2}", "Canada_Summary_TP_SEG", newdeli, "Canada_Usage_TP_SEG");

                foreach (var x in canadasummarytpsegs)
                {
                    if (canadausagetpsegs.Contains(x))
                    {
                        tpsegoutfile.WriteLine("{0}{1}{2}", x, newdeli, x);
                        matches++;
                    }
                    else
                    {
                        tpsegoutfile.WriteLine("{0}{1}{2}", x, newdeli, "");
                    }
                }

                foreach (var x in canadausagetpsegs)
                {
                    if (!canadasummarytpsegs.Contains(x))
                    {
                        tpsegoutfile.WriteLine("{0}{1}{2}", "", newdeli, x);
                    }
                }
            }

            Console.WriteLine("{0} - Canada Usage Tp_Segs", canadausagerecords);
            Console.WriteLine("{0} - Canada Summary Tp_Segs", canadasummaryrecords);
            Console.WriteLine("{0} - Matches", matches);
        }

        static public void MichelinCanadaPOLKTirePotentialSegmentCheckerWINTER() // check the TP_SEG columns 
        {
            // e1platform mich_polk_lookup table tp_seg column should match TP_REGION_SEG_USAGE table tp_seg column
            // e1platform michelin_polk_lookup_winter table tp_seg column should match usage_winter table tp_seg column

            // Each TP_SEG entry in the canada Usage file should be unique...
            // Compare uniques from both files. 
            // Output a file with two columns, matching ... Canada-Usage-TPseg , Summary-File-TPSEG
            // non-matches are listed as "tpseg" , "no match" in appropriate columns

            Console.WriteLine("-Enter Canada Winter Usage File-");
            string canadausagefile = GetAFile();
            char canadausagedeli = GetDelimiter();
            char txtq = GetTXTQualifier();

            Console.WriteLine();
            Console.WriteLine("-Enter Canada Winter Summary File-");
            string canadasummaryfile = GetAFile();
            char canadasummarydeli = GetDelimiter();
            // char txtq = GetTXTQualifier();

            string filefolderpath = GetDesktopDirectory() + @"\michelin_canadapolk_counts";
            if (!Directory.Exists(filefolderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(filefolderpath);
            }

            string tpsegfile = filefolderpath + "\\tpsegmentsWINTER.txt";
            char newdeli = '\t'; // tab

            HashSet<string> canadausagetpsegs = new HashSet<string>();
            HashSet<string> canadasummarytpsegs = new HashSet<string>();

            int matches = 0;
            int canadasummaryrecords = 0;
            int canadausagerecords = 0;

            using (StreamReader ususagereadfile = new StreamReader(canadausagefile))
            {
                string header = ususagereadfile.ReadLine();

                string tpsegname = "TP_SEG"; //column index finder puts everything .toupper().

                //Int32 tpsegindex; //system.int32
                int tpsegindex = 0; // primative data type. does not allow for null values.

                try
                {
                    tpsegindex = ColumnIndexWithQualifier(header, canadausagedeli, txtq, tpsegname);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }

                string line = string.Empty;
                while ((line = ususagereadfile.ReadLine()) != null)
                {
                    List<string> arraybuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        arraybuilder.AddRange(SplitLineWithTxtQualifier(line, canadausagedeli, txtq, false));
                    }
                    else
                    {
                        arraybuilder.AddRange(line.Split(canadausagedeli));
                    }

                    string[] splitline = arraybuilder.ToArray();
                    bool added = canadausagetpsegs.Add(splitline[tpsegindex]);

                    if (added == true)
                    {
                        canadausagerecords++;
                    }
                }
            }

            using (StreamReader ussummaryreadfile = new StreamReader(canadasummaryfile))
            {
                string header = ussummaryreadfile.ReadLine();

                string tpsegname = "TP_SEG"; //column index finder puts everything .toupper().

                //Int32 tpsegindex; //system.int32
                int tpsegindex = 0; // primative data type. does not allow for null values.

                try
                {
                    tpsegindex = ColumnIndexWithQualifier(header, canadausagedeli, txtq, tpsegname);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }

                string line = string.Empty;
                while ((line = ussummaryreadfile.ReadLine()) != null)
                {
                    List<string> arraybuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        arraybuilder.AddRange(SplitLineWithTxtQualifier(line, canadausagedeli, txtq, false));
                    }
                    else
                    {
                        arraybuilder.AddRange(line.Split(canadausagedeli));
                    }

                    string[] splitline = arraybuilder.ToArray();
                    bool added = canadasummarytpsegs.Add(splitline[tpsegindex]);

                    if (added == true)
                    {
                        canadasummaryrecords++;
                    }
                }
            }


            using (StreamWriter tpsegoutfile = new StreamWriter(tpsegfile))
            {
                tpsegoutfile.WriteLine("{0}{1}{2}", "Canada_Summary_TP_SEG", newdeli, "Canada_Usage_TP_SEG");

                foreach (var x in canadasummarytpsegs)
                {
                    if (canadausagetpsegs.Contains(x))
                    {
                        tpsegoutfile.WriteLine("{0}{1}{2}", x, newdeli, x);
                        matches++;
                    }
                    else
                    {
                        tpsegoutfile.WriteLine("{0}{1}{2}", x, newdeli, "");
                    }
                }

                foreach (var x in canadausagetpsegs)
                {
                    if (!canadasummarytpsegs.Contains(x))
                    {
                        tpsegoutfile.WriteLine("{0}{1}{2}", "", newdeli, x);
                    }
                }
            }

            Console.WriteLine("{0} - Canada Usage Tp_Segs", canadausagerecords);
            Console.WriteLine("{0} - Canada Summary Tp_Segs", canadasummaryrecords);
            Console.WriteLine("{0} - Matches", matches);
        }

        static public void MichelinCanadaPOLKGroupCatChecker() // Check if the Group_Categories align between the active_mspns1 and mich_polk_lookup files
        {
            // ACTIVE_MSPNS1 table, columns "GROUPE_CATEGORY", "TIRE_SIZE"
            // 2019-US-PolkSummary-Final.csv file, columns "Group_Cat", "Standard_Tire_Size"

            // look at TIRE_SIZES. then compare on tire size + group category,

            Console.WriteLine("-Enter ACTIVE MSPN File-");
            string activemspnfile = GetAFile();
            char activemspndeli = GetDelimiter();
            char txtq = GetTXTQualifier();

            Console.WriteLine();
            Console.WriteLine("-Enter Canada Summary File-");
            string canadasummaryfile = GetAFile();
            char canadasummarydeli = GetDelimiter();
            // char txtq = GetTXTQualifier();

            Console.WriteLine();
            Console.WriteLine("-Enter Canada Winter Summary File-");
            string canadasummarywinterfile = GetAFile();
            char canadasummarywinterdeli = GetDelimiter();


            string filefolderpath = GetDesktopDirectory() + @"\michelin_canadapolk_counts";
            if (!Directory.Exists(filefolderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(filefolderpath);
            }

            string tiresizegroupcatfile = filefolderpath + "\\tiresizegroupcatcheckfile.txt";
            char newdeli = '\t'; // tab

            // active mspn columns GROUPE_CATEGORY TIRE_SIZE
            // summary file columns Group_Cat Standard_Tire_Size
            // group category only has 6 possible values - Rec/Com, V, Z, Winter, "ENTRY (S,T)", H.
            // "ENTRY (S,T)" - might cause issues, need to maintain the , in the data  in order to be accurate.

            // tire size will be key, categories will go into the list 
            Dictionary<string, List<string>> activemspntiregroupcategories = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> canadasummarytiregroupcategories = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> canadasummarywintertiregroupcategories = new Dictionary<string, List<string>>();
            string[] groupcategories = { "REC/COM", "V", "Z", "Winter", "ENTRY (S,T)", "H" };

            using (StreamReader amspnfile = new StreamReader(activemspnfile))
            {
                string header = amspnfile.ReadLine();

                string tirecolumnname = "TIRE_SIZE";
                string groupcolumnname = "GROUPE_CATEGORY";
                int tiresizecolumn = ColumnIndexWithQualifier(header, activemspndeli, txtq, tirecolumnname);
                int groupcolumn = ColumnIndexWithQualifier(header, activemspndeli, txtq, groupcolumnname);

                string line = string.Empty;
                while ((line = amspnfile.ReadLine()) != null)
                {
                    List<string> arraybuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        arraybuilder.AddRange(SplitLineWithTxtQualifier(line, activemspndeli, txtq, false));
                    }
                    else
                    {
                        arraybuilder.AddRange(line.Split(activemspndeli));
                    }

                    string[] splitline = arraybuilder.ToArray();

                    string keytocheck = splitline[tiresizecolumn];
                    string valuetocheck = splitline[groupcolumn];

                    if (!activemspntiregroupcategories.ContainsKey(keytocheck))
                    {
                        List<string> templist = new List<string>();
                        templist.Add(valuetocheck);

                        activemspntiregroupcategories.Add(keytocheck, templist);
                    }

                    if (!activemspntiregroupcategories[keytocheck].Contains(valuetocheck))
                    {
                        activemspntiregroupcategories[keytocheck].Add(valuetocheck);
                    }
                }
            }

            using (StreamReader summaryfile = new StreamReader(canadasummaryfile))
            {
                string header = summaryfile.ReadLine();

                string tirecolumnname = "Standard_Tire_Size";
                string groupcolumnname = "Group Cat";
                int tiresizecolumn = ColumnIndexWithQualifier(header, activemspndeli, txtq, tirecolumnname);
                int groupcolumn = ColumnIndexWithQualifier(header, activemspndeli, txtq, groupcolumnname);

                string line = string.Empty;
                while ((line = summaryfile.ReadLine()) != null)
                {
                    List<string> arraybuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        arraybuilder.AddRange(SplitLineWithTxtQualifier(line, activemspndeli, txtq, false));
                    }
                    else
                    {
                        arraybuilder.AddRange(line.Split(activemspndeli));
                    }

                    string[] splitline = arraybuilder.ToArray();

                    string keytocheck = splitline[tiresizecolumn];
                    string valuetocheck = splitline[groupcolumn];

                    if (!canadasummarytiregroupcategories.ContainsKey(keytocheck))
                    {
                        List<string> templist = new List<string>();
                        templist.Add(valuetocheck);

                        canadasummarytiregroupcategories.Add(keytocheck, templist);
                    }

                    if (!canadasummarytiregroupcategories[keytocheck].Contains(valuetocheck))
                    {
                        canadasummarytiregroupcategories[keytocheck].Add(valuetocheck);
                    }
                }
            }

            using (StreamReader wintersummaryfile = new StreamReader(canadasummarywinterfile))
            {
                string header = wintersummaryfile.ReadLine();

                string tirecolumnname = "Standard_Tire_Size";
                string groupcolumnname = "Group Cat";
                int tiresizecolumn = ColumnIndexWithQualifier(header, activemspndeli, txtq, tirecolumnname);
                int groupcolumn = ColumnIndexWithQualifier(header, activemspndeli, txtq, groupcolumnname);

                string line = string.Empty;
                while ((line = wintersummaryfile.ReadLine()) != null)
                {
                    List<string> arraybuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        arraybuilder.AddRange(SplitLineWithTxtQualifier(line, activemspndeli, txtq, false));
                    }
                    else
                    {
                        arraybuilder.AddRange(line.Split(activemspndeli));
                    }

                    string[] splitline = arraybuilder.ToArray();

                    string keytocheck = splitline[tiresizecolumn];
                    string valuetocheck = splitline[groupcolumn];

                    if (!canadasummarywintertiregroupcategories.ContainsKey(keytocheck))
                    {
                        List<string> templist = new List<string>();
                        templist.Add(valuetocheck);

                        canadasummarywintertiregroupcategories.Add(keytocheck, templist);
                    }

                    if (!canadasummarywintertiregroupcategories[keytocheck].Contains(valuetocheck))
                    {
                        canadasummarywintertiregroupcategories[keytocheck].Add(valuetocheck);
                    }
                }
            }

            using (StreamWriter outfile = new StreamWriter(tiresizegroupcatfile))
            {
                // return only records from the summary file that are not found in the active mspn file.
                // group category only has 6 possible values - Rec/Com, V, Z, Winter, "ENTRY (S,T)", H.

                List<string> header = new List<string>();
                header.Add("GroupMatchError");
                header.Add("TireSize");
                header.Add("Rec/Com");
                header.Add("V");
                header.Add("Z");
                header.Add("Winter");
                header.Add("ENTRY (S,T)");
                header.Add("H");
                outfile.WriteLine(string.Join(newdeli.ToString(), header.ToArray()));

                foreach (var tiresize in canadasummarytiregroupcategories.Keys)
                {
                    if (!activemspntiregroupcategories.ContainsKey(tiresize)) // if the tire size is not found.
                    {
                        //output the tire size and the group categories.
                        string[] categories = new string[6];
                        string error = string.Empty;
                        bool matchfound = false;

                        //for (int index = 0; index < groupcategories.Length; index++)
                        //{
                        //   if (ussummarytiregroupcategories[tiresize].Contains(groupcategories[index])) 
                        //   {
                        //      categories[index] = groupcategories[index];
                        //      matchfound = true; //shows that we found at least one match.
                        //   }
                        //}

                        foreach (var category in groupcategories) //loop through all possible matches. any matches get added 
                        {
                            if (canadasummarytiregroupcategories[tiresize].Contains(category))
                            {
                                int index = Array.IndexOf(groupcategories, category);
                                categories[index] = category;

                                matchfound = true;
                            }
                        }

                        if (matchfound == true)
                        {
                            List<string> linebuilder = new List<string>();
                            error = "NewTire"; // new tire has been added.
                            linebuilder.Add(error);
                            linebuilder.Add(tiresize);
                            foreach (var category in categories)
                            {
                                linebuilder.Add(category);
                            }

                            string newline = string.Join(newdeli.ToString(), linebuilder.ToArray());

                            outfile.WriteLine(newline);
                        }
                        else
                        {
                            List<string> linebuilder = new List<string>();
                            error = "NewTireNotValidCategory"; // new tire added and group category does NOT match what it should.
                            linebuilder.Add(error);
                            linebuilder.Add(tiresize);
                            foreach (var category in canadasummarytiregroupcategories[tiresize]) //just write existing group categories in order they appear.
                            {
                                linebuilder.Add(category);
                            }

                            string newline = string.Join(newdeli.ToString(), linebuilder.ToArray());

                            outfile.WriteLine(newline);
                        }

                    }
                    else //tire exists.
                    {
                        string[] categories = new string[6];
                        List<string> badcategory = new List<string>();
                        string error = string.Empty;
                        string categoryvaliderror = string.Empty;
                        bool matchfound = true;
                        bool newcategory = false;

                        foreach (var category in canadasummarytiregroupcategories[tiresize]) //tire exists, so compare group categories from both dictionaries.
                        {
                            if (activemspntiregroupcategories[tiresize].Contains(category)) // category found in both dicts.
                            {
                                if (!groupcategories.Contains(category)) // validate it is a good group categories. if it is good and matches do nothing.
                                {
                                    badcategory.Add(category);
                                    matchfound = false;
                                }
                            }
                            else //category not found in original file
                            {
                                if (groupcategories.Contains(category)) // validate it is a good group categories.
                                {
                                    int index = Array.IndexOf(groupcategories, category);
                                    categories[index] = category;

                                    newcategory = true;
                                }
                                else
                                {
                                    badcategory.Add(category);
                                    matchfound = false;
                                }
                            }
                        }

                        if (matchfound == false)
                        {
                            List<string> linebuilder = new List<string>();
                            categoryvaliderror = "NotValidCategory";
                            linebuilder.Add(categoryvaliderror);
                            linebuilder.Add(tiresize);
                            foreach (var category in badcategory) // write categories that do not match template.
                            {
                                linebuilder.Add(category);
                            }

                            string newline = string.Join(newdeli.ToString(), linebuilder.ToArray());

                            outfile.WriteLine(newline);
                        }

                        if (newcategory == true)
                        {
                            //tire exists but there is a new category.
                            List<string> linebuilder = new List<string>();
                            error = "NewCategory";
                            linebuilder.Add(error);
                            linebuilder.Add(tiresize);
                            foreach (var category in categories) // write categories that do not match template.
                            {
                                linebuilder.Add(category);
                            }

                            string newline = string.Join(newdeli.ToString(), linebuilder.ToArray());

                            outfile.WriteLine(newline);
                        }
                    }
                }

                foreach (var tiresize in canadasummarywintertiregroupcategories.Keys)
                {
                    if (!activemspntiregroupcategories.ContainsKey(tiresize)) // if the tire size is not found.
                    {
                        //output the tire size and the group categories.
                        string[] categories = new string[6];
                        string error = string.Empty;
                        bool matchfound = false;

                        //for (int index = 0; index < groupcategories.Length; index++)
                        //{
                        //   if (ussummarytiregroupcategories[tiresize].Contains(groupcategories[index])) 
                        //   {
                        //      categories[index] = groupcategories[index];
                        //      matchfound = true; //shows that we found at least one match.
                        //   }
                        //}

                        foreach (var category in groupcategories) //loop through all possible matches. any matches get added 
                        {
                            if (canadasummarywintertiregroupcategories[tiresize].Contains(category))
                            {
                                int index = Array.IndexOf(groupcategories, category);
                                categories[index] = category;

                                matchfound = true;
                            }
                        }

                        if (matchfound == true)
                        {
                            List<string> linebuilder = new List<string>();
                            error = "NewTireWinter"; // new tire has been added.
                            linebuilder.Add(error);
                            linebuilder.Add(tiresize);
                            foreach (var category in categories)
                            {
                                linebuilder.Add(category);
                            }

                            string newline = string.Join(newdeli.ToString(), linebuilder.ToArray());

                            outfile.WriteLine(newline);
                        }
                        else
                        {
                            List<string> linebuilder = new List<string>();
                            error = "NewTireNotValidCategoryWinter"; // new tire added and group category does NOT match what it should.
                            linebuilder.Add(error);
                            linebuilder.Add(tiresize);
                            foreach (var category in canadasummarywintertiregroupcategories[tiresize]) //just write existing group categories in order they appear.
                            {
                                linebuilder.Add(category);
                            }

                            string newline = string.Join(newdeli.ToString(), linebuilder.ToArray());

                            outfile.WriteLine(newline);
                        }

                    }
                    else //tire exists.
                    {
                        string[] categories = new string[6];
                        List<string> badcategory = new List<string>();
                        string error = string.Empty;
                        string categoryvaliderror = string.Empty;
                        bool matchfound = true;
                        bool newcategory = false;

                        foreach (var category in canadasummarywintertiregroupcategories[tiresize]) //tire exists, so compare group categories from both dictionaries.
                        {
                            if (activemspntiregroupcategories[tiresize].Contains(category)) // category found in both dicts.
                            {
                                if (!groupcategories.Contains(category)) // validate it is a good group categories. if it is good and matches do nothing.
                                {
                                    badcategory.Add(category);
                                    matchfound = false;
                                }
                            }
                            else //category not found in original file
                            {
                                if (groupcategories.Contains(category)) // validate it is a good group categories.
                                {
                                    int index = Array.IndexOf(groupcategories, category);
                                    categories[index] = category;

                                    newcategory = true;
                                }
                                else
                                {
                                    badcategory.Add(category);
                                    matchfound = false;
                                }
                            }
                        }

                        if (matchfound == false)
                        {
                            List<string> linebuilder = new List<string>();
                            categoryvaliderror = "NotValidCategoryWinter";
                            linebuilder.Add(categoryvaliderror);
                            linebuilder.Add(tiresize);
                            foreach (var category in badcategory) // write categories that do not match template.
                            {
                                linebuilder.Add(category);
                            }

                            string newline = string.Join(newdeli.ToString(), linebuilder.ToArray());

                            outfile.WriteLine(newline);
                        }

                        if (newcategory == true)
                        {
                            //tire exists but there is a new category.
                            List<string> linebuilder = new List<string>();
                            error = "NewCategoryWinter";
                            linebuilder.Add(error);
                            linebuilder.Add(tiresize);
                            foreach (var category in categories) // write categories that do not match template.
                            {
                                linebuilder.Add(category);
                            }

                            string newline = string.Join(newdeli.ToString(), linebuilder.ToArray());

                            outfile.WriteLine(newline);
                        }
                    }
                }
            }
        }


    }
}
