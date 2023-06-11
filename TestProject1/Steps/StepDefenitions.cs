using BuggyProject;
using BuggyProject.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Support.UI;
using SpecFlowBuggy.Context;
using SpecFlowBuggy.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BuggyProject.Steps
{
    [Binding]
    public class StepDefenitions 
    {
        private LoginPage _Loginpage { get; }
        

        private DataContext DataContext;
        private ProfilePage  _ProfilePage { get; }
        public StepDefenitions(LoginPage loginPage, ProfilePage profilePage, DataContext dataContext)
        {
            _Loginpage = loginPage;
            _ProfilePage = profilePage;
            DataContext = dataContext;
        }


        [Then(@"I close the application")]
        public void ThenICloseTheApplication()
        {
            _Loginpage.CloseApplication();
        }

        [When(@"I open the buggy application home page")]
        [Then(@"I open the buggy application home page")]
        [Given(@"I open the buggy application home page")]
        public void GivenIOpenTheBuggyApplication()
        {
            _Loginpage.NavigatetoBuggyHome();
            _Loginpage.Waitfor5seconds();
        }


        [Then(@"I validate successfull login")]
        public void ThenIValidateSuccessfullLogin()
        {
            _Loginpage.Waitfor2seconds();
            Assert.IsTrue(_Loginpage.ProfileLinkButtonVisible(), "profile button not visible");
        }


        [When(@"I fill in login Information")]
        public void WhenIFillInLoginInformation(Table table)
        {
            foreach (var item in table.Rows)

            {
                string login = item.GetString("login");
                string password = item.GetString("password");
                if (login != null && login != string.Empty)
                {
                    _Loginpage.SetUsername(login);
                    _Loginpage.Waitfor2seconds();
                }
                if (password != null && password != string.Empty)
                {
                    _Loginpage.SetPassword(password);
                    _Loginpage.Waitfor2seconds();
                }
            }
        }

        [Then(@"I Select category ([^']*)")]
        public void ThenISelectCategory(string category)
        {
            if(category == "Popular Make") 
            {
                _ProfilePage.clickPopularMake();
                _Loginpage.Waitfor5seconds();

            }

            if (category == "Popular Model")
            {
                _ProfilePage.clickPopularModel();
                _Loginpage.Waitfor5seconds();

            }
        }




        [Then(@"I vote for car model ([^']*)")]
        public void ThenIVoteForCarModel(string mito)
        {
            _ProfilePage.selectamodel(mito);
            _Loginpage.Waitfor5seconds();
            _ProfilePage.Typecomments("Test Comment");
            _ProfilePage.clickVoteButton();
            _Loginpage.Waitfor5seconds();
        }

        [Then(@"I validate successful voting message is shown")]
        public void ThenIValidateSuccessfulVotingMessageIsShown()
        {
            Assert.IsTrue(_ProfilePage.IsThankYouVoteDisplayed(), "Voting successful message is not shown");
        }


        [Then(@"I login to the application with credentials from context")]
        public void ThenILoginToTheApplicationWithCredentialsFromContext()
        {
         
             _Loginpage.SetUsername(DataContext.LoginName);
            _Loginpage.Waitfor2seconds();
            _Loginpage.SetPassword(DataContext.LoginPassword);
        
        }


       


        [Then(@"I Validate error message for invalid login")]
        public void ThenIValidateErrorMessageForInvalidLogin()
        {
            string expectedvalidationmessage = "Invalid username/password";
            string actualvalidationmessage = _Loginpage.ValidationMessageforLogin();
            Assert.AreEqual(expectedvalidationmessage, actualvalidationmessage, "validation message not found or doesnt match");
        }

        [Then(@"I click login button")]
        public void ThenIClickLoginButton()
        {
            _Loginpage.clickLoginButton();
        }


      
      

        
        }


       

       

    }

