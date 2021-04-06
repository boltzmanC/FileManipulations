using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.Data;
using FluentFTP;
//using ExcelDataReader;


namespace FileManipulations
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(150, 45);
            int bufferwidth = Console.BufferWidth;
            int bufferheight = 600;
            Console.SetBufferSize(bufferwidth, bufferheight);


            // GO

            FileFormatCheckerFixer();


            // Manual running-------------

            //AddStringToColumnValues();
            //AddStringAsNewColumnValue();
            //AppendValueToEachLineInFile();
            //BGToZipUrbanicityAverage();
            //BehaviorAnalyzerSorting();
            //CopyColumnToNewFile();
            //CopyColumnsToNewFile(); //better.
            //CombineFiles();
            //CSTUsageMetricsFilter();
            //Dedupesaveextravalues();
            //EditLineInListOfFiles();
            //FileInfo();
            //FindDatesBeforeX();
            //FindIDsInTwoFiles();
            //FixedWidthToPipeDelimited();
            //FormatDateColumn();
            //FormatZipCodesAddLeadingZeroes();
            //NumericValueCheck();
            //PullBlankEmptyOrZeroValueRecords();
            //PullRecordsWithORListofStringorChars();
            //PullRecordsWithValueInColumn_s();
            //PullRecordsWithValueXInColumnY();
            //PullRandomSubsetofLengthX();
            //ReadTwoLines();
            //RemoveDataFromColumn();
            //UniqueValueCheck();
            //SkipUserSpecifiedLines();
            //SuperStringStripper();
            //TestColumnNamesFromDefinitionFile();
            //VlookupAppendColumn(); //does not accept files with text qualifiers
            //VLookupAppendColumnRows();
            //VlookupKeepNotFoundFromOriginalFile();
            //XLSXToCSV();


            //CostarPointsFiles(); //add check for unique variable IDS first.
            //CostarPointsFilesManualCheck();

            //CostarAreaFiles();
            //CostarAreaFilesManualCheck();
            //CostarAreaFilesSummaries(); //sums total variable values.. should be less than or eqaul to national totals.

            //CoStarUSManualTestGapFile();

            //CostarCanadaTestGapFile();
            //CostarCanadaManualTestGapfile();
            //CostarCanadaReformatNightlyFeedOutput();

            //CostarSumDataColumns();

            //Michelin Monthly testing...
            //MichelinMonthlyFileCleaner();

            //Michelin Polk tables
            //MichelinPOLKZipReaderMultiTask();
            //
            //MichelinPOLKNewZipFinder();
            //
            //MichelinPOLKZipCountsDiffReader();
            //MichelinPOLKPolkKeyCountsDiffReader();
            //MichelinPOLKStateCountsDiffReader();
            //
            //MichelinPOLKVehicleInfoFileCleaner();
            //MichelinPOLKMichelintoPolkCrossWalk();
            //MichelinPOLKTirePotentialSegmentChecker();
            //
            //MichelinPOLKGroupCatChecker();
            //
            //michelin canada
            //MichelinCanadaPOLKReaderMultiTask();

            //MichelinCanadaPOLKNewfsaFinder();
            //MichelinCanadaPOLKfsaCountsDiffReader();
            //MichelinCanadaPOLKPolkKeyCountsDiffReader();
            //MichelinCanadaPOLKProvinceCountsDiffReader();
            //MichelinCanadaPOLKVehicleInfoFileCleaner();
            //MichelinCanadaPOLKMichelintoPolkCrossWalk();
            //MichelinCanadaPOLKTirePotentialSegmentChecker();
            //MichelinCanadaPOLKTirePotentialSegmentCheckerWINTER();
            //MichelinCanadaPOLKGroupCatChecker();

            //foreach (KeyValuePair<string, List<string>> entry in dict)

            //Collapse all methods -> CTRL + M CTRL + O
        }

        static void FileFormatCheckerFixer()
        {
            // this will launch the default browser    
            //System.Diagnostics.Process.Start("https://confluence.nexgen.neustar.biz/display/E1/File+Format+Checker+Fixer");

            string choice = string.Empty;

            while (choice != "exit" || choice != "Exit")
            {
                Console.WriteLine();

                Console.WriteLine("File Formatting: ");
                Console.WriteLine("{0,5}{1,-10}", "1. ", "String Stripper.");
                Console.WriteLine("{0,5}{1,-10}", "2. ", "Verify Line Length.");
                Console.WriteLine("{0,5}{1,-10}", "3. ", "Trim Whitespace.");
                Console.WriteLine("{0,5}{1,-10}", "4. ", "Change Delimiter.");
                Console.WriteLine("{0,5}{1,-10}", "5. ", "Combine Two Columns.");
                Console.WriteLine();

                Console.WriteLine("File Manipulation");
                Console.WriteLine("{0,5}{1,-10}", "6. ", "Combine Files"); // promts user for files and if it has headers. (files MUST BE IN THE SAME FORMAT)
                Console.WriteLine("{0,5}{1,-10}", "7. ", "Copy File"); //copies file, use to get rid of hidden formats within the file.
                Console.WriteLine("{0,5}{1,-10}", "8. ", "Dedupe column");
                Console.WriteLine("{0,5}{1,-10}", "9. ", "Vlookup Append Column");
                Console.WriteLine("{0,5}{1,-10}", "10. ", "Vlookup Append Column Rows");
                Console.WriteLine("{0,5}{1,-10}", "11. ", "Add String to Column Values");
                Console.WriteLine("{0,5}{1,-10}", "12. ", "Add String As New Column Value");
                Console.WriteLine("{0,5}{1,-10}", "13. ", "Remove Data From Column");
                Console.WriteLine();

                Console.WriteLine("Pull Data from File");
                Console.WriteLine("{0,5}{1,-10}", "14. ", "Get Subset of Records");
                Console.WriteLine("{0,5}{1,-10}", "15. ", "Break File Into # of Subsets.");
                Console.WriteLine("{0,5}{1,-10}", "16. ", "Copy Column(s) with value to New File.");
                Console.WriteLine("{0,5}{1,-10}", "17. ", "Copy Columns to New File.");
                Console.WriteLine("{0,5}{1,-10}", "18. ", "Pull Blank Empty or Zero Value Records"); //broken
                Console.WriteLine("{0,5}{1,-10}", "19. ", "Pull Random Subet of Length x");
                Console.WriteLine("{0,5}{1,-10}", "20. ", "Pull Records with Value x in column y.");
                Console.WriteLine("{0,5}{1,-10}", "21. ", "Pull Records with value in column_s.");
                Console.WriteLine("{0,5}{1,-10}", "22. ", "Pull records with OR list of strings or chars.");
                Console.WriteLine();

                Console.WriteLine("Monthly File Processes");
                Console.WriteLine("{0,5}{1,-10}", "23. ", "Check format and build new .definition file");

                //Console.WriteLine("CST Specific Tasks:");
                //Console.WriteLine("{0,5}{1,-10}", "10. ", "BG to Zip Urbanicity Average"); //report for this exisits in e1support instance.

                Console.WriteLine();
                Console.WriteLine("{0,5}{1,-10}", "exit. ", "To close the console.");
                Console.WriteLine();

                Console.Write("Your choice: ");

                //Get user input.
                string input = Console.ReadLine();

                //Switch Statements.
                switch (input)
                {
                    // File Formatting.
                    case "1":
                        FunctionTools.StringStrip();
                        break;
                    case "2":
                        FunctionTools.VerifyLineLength();
                        break;
                    case "3":
                        FunctionTools.TrimWhitespace();
                        break;
                    case "4":
                        FunctionTools.ChangeDelimeter();
                        break;
                    case "5":
                        FunctionTools.CombineTwoColumns();
                        break;

                    // File Manipulation.
                    case "6":
                        FileFormatCheckerFixers.CombineFiles();
                        break;
                    case "7":
                        FileFormatCheckerFixers.CopyFile();
                        break;
                    case "8":
                        FileFormatCheckerFixers.UniqueValueCheck();
                        break;
                    case "9":
                        FileFormatCheckerFixers.VlookupAppendColumn();
                        break;
                    case "10":
                        FileFormatCheckerFixers.VLookupAppendColumnRows();
                        break;
                    case "11":
                        FileFormatCheckerFixers.AddStringToColumnValues();
                        break;
                    case "12":
                        FileFormatCheckerFixers.AddStringAsNewColumnValue();
                        break;
                    case "13":
                        FileFormatCheckerFixers.RemoveDataFromColumn();
                        break;

                    //Pull Data From File.
                    case "14":
                        FileFormatCheckerFixers.GetSubsetOfRecords();
                        break;
                    case "15":
                        FileFormatCheckerFixers.BreakOneFileIntoMany();
                        break;
                    case "16":
                        FileFormatCheckerFixers.CopyColumnsWithValueToNewFile();
                        break;
                    case "17":
                        FileFormatCheckerFixers.CopyColumnsToNewFile();
                        break;
                    case "18":
                        FileFormatCheckerFixers.PullBlankEmptyOrZeroValueRecords();
                        break;
                    case "19":
                        FileFormatCheckerFixers.PullRandomSubsetofLengthX(); // not really working.
                        break;
                    case "20":
                        FileFormatCheckerFixers.PullRecordsWithValueXInColumnY();
                        break;
                    case "21":
                        FileFormatCheckerFixers.PullRecordsWithValueInColumn_s();
                        break;
                    case "22":
                        FileFormatCheckerFixers.PullRecordsWithORListofStringorChars();
                        break;

                    case "23":
                        FileFormatCheckerFixers.TestColumnNamesFromDefinitionFile();
                        break;

                    //end
                    case "Exit":
                    case "exit":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("not a valid input");
                        FileFormatCheckerFixer(); //start over
                        break;
                }
            }
        }


    }
}
