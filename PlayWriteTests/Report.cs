using System;
using System.Collections.Generic;
using System.Text;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
namespace PlayWriteTests
{
    internal class Report
    {
        public static ExtentReports CreateReport()
        {
            //
            string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", ".."));
            string reportDirectory = Path.Combine(projectRoot, "TestReports");
            //
           // string reportDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestResults");
            string reportPath = Path.Combine(reportDirectory, "Report.html");
            
            if (!Directory.Exists(reportDirectory))
            {
                Directory.CreateDirectory(reportDirectory);
            }
            var sparkReporter = new ExtentSparkReporter(reportPath);
            sparkReporter.Config.TimelineEnabled = true;
            sparkReporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Standard;
            var extent = new ExtentReports();
            extent.AttachReporter(sparkReporter);
            //var sparkReporter = new ExtentSparkReporter("TestReport.html");
            //var extent = new ExtentReports();
            //extent.AttachReporter(sparkReporter);
            return extent;
        }
    }
}
