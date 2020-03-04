using System;
using TechTalk.SpecFlow;

namespace Login_Page
{
    [Binding]
    public class TimeAndMaterialSteps
    {
        [Then(@"I should be able to edit time record with updated information")]
        public void ThenIShouldBeAbleToEditTimeRecordWithUpdatedInformation()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
