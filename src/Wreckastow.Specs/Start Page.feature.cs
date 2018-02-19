﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.3.0.0
//      SpecFlow Generator Version:2.3.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Wreckastow.Specs
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Start Page")]
    public partial class StartPageFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Start Page.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Start Page", "\tAs the owner of WreckaStow\r\n\tI want the front page to list the latest records\r\n\t" +
                    "So that someone might want to make a purchase\r\n\r\n\tAs a customer\r\n\tI expect the f" +
                    "ront page to show some records\r\n\tOr I\'ll take my business elsewhere", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 10
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Title",
                        "Artist",
                        "Date Available"});
            table1.AddRow(new string[] {
                        "Purple Rain",
                        "Prince & The Revolution",
                        "2017-12-24"});
            table1.AddRow(new string[] {
                        "Lovesexy",
                        "Prince",
                        "2018-02-12"});
            table1.AddRow(new string[] {
                        "Plectrumelectrum",
                        "3rdeyegirl",
                        "2018-01-02"});
#line 11
 testRunner.Given("these albums are available:", ((string)(null)), table1, "Given ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Show Available Records")]
        public virtual void ShowAvailableRecords()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Show Available Records", ((string[])(null)));
#line 17
this.ScenarioSetup(scenarioInfo);
#line 10
this.FeatureBackground();
#line 18
 testRunner.When("someone visits the start page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Title"});
            table2.AddRow(new string[] {
                        "Purple Rain"});
            table2.AddRow(new string[] {
                        "Lovesexy"});
            table2.AddRow(new string[] {
                        "Plectrumelectrum"});
#line 19
 testRunner.Then("they see these albums:", ((string)(null)), table2, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Show Newest Records First")]
        public virtual void ShowNewestRecordsFirst()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Show Newest Records First", ((string[])(null)));
#line 25
this.ScenarioSetup(scenarioInfo);
#line 10
this.FeatureBackground();
#line 26
 testRunner.When("someone visits the start page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Title"});
            table3.AddRow(new string[] {
                        "Lovesexy"});
            table3.AddRow(new string[] {
                        "Plectrumelectrum"});
            table3.AddRow(new string[] {
                        "Purple Rain"});
#line 27
 testRunner.Then("they see these albums in this order:", ((string)(null)), table3, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Album List Should Link To Details Page")]
        public virtual void AlbumListShouldLinkToDetailsPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Album List Should Link To Details Page", ((string[])(null)));
#line 33
this.ScenarioSetup(scenarioInfo);
#line 10
this.FeatureBackground();
#line 34
 testRunner.When("someone visits the start page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Title"});
            table4.AddRow(new string[] {
                        "Purple Rain"});
            table4.AddRow(new string[] {
                        "Lovesexy"});
            table4.AddRow(new string[] {
                        "Plectrumelectrum"});
#line 35
 testRunner.Then("they see these albums:", ((string)(null)), table4, "Then ");
#line 40
 testRunner.And("each album has a link to its details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
