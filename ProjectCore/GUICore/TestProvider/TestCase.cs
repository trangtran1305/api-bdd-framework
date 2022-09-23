using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCore.GUICore.TestProvider
{
    public class OriginalTestCase
    {
        public string TestCaseID { get; set; }
        public string Description { get; set; }
       
        public List<TestStep> TestSteps { get; set; }

    }   
    public class TestCaseForRun
    {
        public string TestCaseID { get; set; }
        public string Description { get; set; }
        public List<TestStepsGroup> TestStepsGroups { get; set; }    
    }

    public class TestStepsGroup
    {
        public TestStep MainStep { get; set; }
        public List<TestStep> SubSteps { get; set; }
        
    }

    public class TestStep
    {
        public string StepId { get; set; }
        public string StepName { get; set; }
        public string StepData { get; set; }
    }
    public class ActualResult
    {
        public string TestCaseID { get; set; }
        public string Description { get; set; }
        public string TestResult { get; set; }
    }
}
