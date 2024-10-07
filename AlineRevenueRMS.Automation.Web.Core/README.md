# Introduction
`AlineRevenueRMS.Automation.Web.Core` is Selenium.WebDriver wrapper implementing Page Object/Page Element Model design pattern.

For stable and fast Web UI tests.

# Getting Started
* `WrappedElement` is a class that identifies web elements by locator and contains all needed for interacting with them. Example: Click, SendKeys, Clear, etc. All actions contain an explicit wait.
* `WrappedElementsCollections` is the class that describes a collection of elements on the page, found by the locator. It is useful for working with a group of identical elements. Once describe a collection it is possible to filter WrappedElements by conditions or by index like a simple array.
* `Condition` is an important part of the project. Contain such conditions as: Visible, Selected, Text, Count, etc. Condition is key for the waiting mechanism. It used by `Should` and `ShouldNot` methods. Also, it used for filtering within collections. 

Examples:
`Header.Should(Be.Visible)` Checking that header is loaded.
`SearchResultCollection.Should(Have.CountAtLeast(1))` Checking that search result is not empty.
`ToolsCollection.FindBy(Have.CssClass("researcher"), "Researcher tool")` Filtering collection by the Css class.