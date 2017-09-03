
using TestAutomation.WebDriver.WebComponents;
using TestAutomation.WebComponents.Interfaces;
using TestAutomation.WebComponents.ObjectProperties;
/// <summary>
/// Account Summary page object which will be used in business logic
/// </summary>
/// <author>Niraj Kumar</author>
namespace efrAutomation.Factory.PageFactory
{
    public class AccountCasePage
    {

        public IWebButton BtnOpenCase {  get { return new WebButton(FindBy.id, "btnOpenCase"); } }
        
    }      

}
