using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace XUnitTestProject1
{
    public abstract class TestRunnerBase
    {
        public virtual void DiscoverTestsCases()
        {
            //TODO
        }

        public virtual void RunTests()
        {
            //TODO
        }

        public abstract string ReturnSummary();
    }
    
    public class BasicTestRunner : TestRunnerBase
    {
        private List<TestObject> testObjects = new List<TestObject>();


        public void Run()
        {
            DiscoverTestsCases();
            RunTests();
            ReturnSummary();
        }
        public override  string ReturnSummary()
        {
            //TODO
            return  String.Empty;
        }
    }


    public class CustomTestRunner : TestRunnerBase
    {
        private List<TestObject> testObjects = new List<TestObject>();


        public void Run()
        {
            Initialization();
            DiscoverTestsCases();
            RunTests();
            ReturnSummary();
        }

        private void Initialization()
        {
            throw new NotImplementedException();
        }

        public override string ReturnSummary()
        {
            //TODO
            //TODO return html formated
            //Run execution time 
            return String.Empty;
        }
    }

}