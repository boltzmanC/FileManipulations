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
            FunctionTools.ConsoleSettings();


            // Main Menu -----------------------------------------------
            FileFormatCheckerFixers.FileFormatCheckerFixer();

            // Michelin Monthly File Tester -----------------------------
            //MichelinMonthlyFileTesters.MichelinMonthlyFileCleaner();


            // Manual running File Processes -------------

            //FileFormatCheckerFixers.AddStringToColumnValues();
            //FileFormatCheckerFixers.AddStringAsNewColumnValue();
            //FileFormatCheckerFixers.AppendValueToEachLineInFile();
            //FileFormatCheckerFixers.CopyColumnsToNewFile();
            //FileFormatCheckerFixers.CopyColumnsWithValueToNewFile();
            //FileFormatCheckerFixers.CombineFiles();
            //FileFormatCheckerFixers.Dedupesaveextravalues();
            //FileFormatCheckerFixers.FormatDateColumn();
            //FileFormatCheckerFixers.FormatZipCodesAddLeadingZeroes();
            //FileFormatCheckerFixers.PullBlankEmptyOrZeroValueRecords();
            //FileFormatCheckerFixers.PullRecordsWithORListofStringorChars();
            //FileFormatCheckerFixers.PullRecordsWithValueInColumn_s();
            //FileFormatCheckerFixers.PullRecordsWithValueXInColumnY();
            //FileFormatCheckerFixers.PullRandomSubsetofLengthX();
            //FileFormatCheckerFixers.RemoveDataFromColumn();
            //FileFormatCheckerFixers.UniqueValueCheck();
            //FileFormatCheckerFixers.SuperStringStripper();
            //FileFormatCheckerFixers.TestColumnNamesFromDefinitionFile();
            //FileFormatCheckerFixers.VlookupAppendColumn(); //does not accept files with text qualifiers
            //FileFormatCheckerFixers.VLookupAppendColumnRows();
            //FileFormatCheckerFixers.VlookupKeepNotFoundFromOriginalFile();


            // one time use may need adjusting per run -------------------

            //SingleUse.NumericValueCheck();
            //SingleUse.FindIDsInTwoFiles();
            //SingleUse.BGToZipUrbanicityAverage();
            //SingleUse.BehaviorAnalyzerSorting();
            //SingleUse.CSTUsageMetricsFilter();
            //SingleUse.EditLineInListOfFiles();
            //SingleUse.FindDatesBeforeX();
            //SingleUse.FixedWidthToPipeDelimited();
            //SingleUse.ReadTwoLines();
            //SingleUse.SkipUserSpecifiedLines();


            //Costar ---------------------------------
            //CoStarTester.CostarPointsFiles(); //add check for unique variable IDS first.
            //CoStarTester.CostarPointsFilesManualCheck();

            //CoStarTester.CostarAreaFiles();
            //CoStarTester.CostarAreaFilesManualCheck();
            //CoStarTester.CostarAreaFilesSummaries(); //sums total variable values.. should be less than or eqaul to national totals.

            //CoStarTester.CoStarUSManualTestGapFile();

            //CoStarTester.CostarSumDataColumns();

            // CoStar Canada --------------------------------
            //CoStarTester.CostarCanadaTestGapFile();
            //CoStarTester.CostarCanadaManualTestGapfile();
            //CoStarTester.CostarCanadaReformatNightlyFeedOutput();



            // Michelin Polk tables ----------------------------
            //MichelinAnnualTester.MichelinPOLKReaderMultiTask();

            //MichelinAnnualTester.MichelinPOLKNewZipFinder();
            //MichelinAnnualTester.MichelinPOLKZipCountsDiffReader();
            //MichelinAnnualTester.MichelinPOLKPolkKeyCountsDiffReader();
            //MichelinAnnualTester.MichelinPOLKStateCountsDiffReader();
            //MichelinAnnualTester.MichelinPOLKVehicleInfoFileCleaner();
            //MichelinAnnualTester.MichelinPOLKMichelintoPolkCrossWalk();
            //MichelinAnnualTester.MichelinPOLKTirePotentialSegmentChecker();
            //MichelinAnnualTester.MichelinPOLKGroupCatChecker();

            // michelin canada --------------------
            //MichelinAnnualTester.MichelinCanadaPOLKReaderMultiTask();

            //MichelinAnnualTester.MichelinCanadaPOLKNewfsaFinder();
            //MichelinAnnualTester.MichelinCanadaPOLKfsaCountsDiffReader();
            //MichelinAnnualTester.MichelinCanadaPOLKPolkKeyCountsDiffReader();
            //MichelinAnnualTester.MichelinCanadaPOLKProvinceCountsDiffReader();
            //MichelinAnnualTester.MichelinCanadaPOLKVehicleInfoFileCleaner();
            //MichelinAnnualTester.MichelinCanadaPOLKMichelintoPolkCrossWalk();
            //MichelinAnnualTester.MichelinCanadaPOLKTirePotentialSegmentChecker();
            //MichelinAnnualTester.MichelinCanadaPOLKTirePotentialSegmentCheckerWINTER();
            //MichelinAnnualTester.MichelinCanadaPOLKGroupCatChecker();

        }
    }
}
