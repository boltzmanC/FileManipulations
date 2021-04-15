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


            // Main Menu


            //FileFormatCheckerFixers.FileFormatCheckerFixer();

            MichelinMonthlyFileTesters.MichelinMonthlyFileCleaner();


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

        


    }
}
