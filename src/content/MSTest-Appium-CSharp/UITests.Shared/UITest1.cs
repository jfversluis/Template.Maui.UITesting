using Microsoft.VisualStudio.TestTools.UnitTesting;

// You will have to make sure that all the namespaces match
// between the different platform specific projects and the shared
// code files. This has to do with how we initialize the AppiumDriver
// through the AppiumSetup.cs files and MSTest AssemblyInitialize attributes.
// Also see: https://learn.microsoft.com/dotnet/core/testing/unit-testing-with-mstest
namespace UITests;

// This is an example of tests that do not need anything platform specific.
// Typically you will want all your tests to be in the shared project so they are ran across all platforms.
[TestClass]
public class UITest1 : BaseTest
{
	[TestMethod]
	public void AppLaunches()
	{
		App.GetScreenshot().SaveAsFile($"{nameof(AppLaunches)}.png");
	}
}