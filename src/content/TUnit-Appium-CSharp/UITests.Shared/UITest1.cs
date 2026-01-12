using TUnit;

// You will have to make sure that all the namespaces match
// between the different platform specific projects and the shared
// code files. This has to do with how we initialize the AppiumDriver
// through the AppiumSetup.cs files and TUnit [Before(Assembly)] attributes.
// Also see: https://tunit.dev/docs/test-lifecycle/setup#beforeassembly
namespace UITests;

// This is an example of tests that do not need anything platform specific.
// Typically you will want all your tests to be in the shared project so they are ran across all platforms.
public class UITest1 : BaseTest
{
    [Test]
    public void AppLaunches()
    {
        App.GetScreenshot().SaveAsFile($"{nameof(AppLaunches)}.png");
    }
}