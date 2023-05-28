using NLog;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.BaseEntities
{
    public abstract class BasePage
    {
        protected static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        protected static int WAIT_FOR_PAGE_LOADING_TIME = 60;
        protected static IWebDriver? Driver;

        public abstract void OpenPage();
        public abstract bool IsPageOpened();

        public BasePage()
        {
        }

        public BasePage(IWebDriver? driver, bool openPageByUrl)
        {
            Driver = driver;

            if (openPageByUrl)
            {
                OpenPage();
            }
        }
    }
}
