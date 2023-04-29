"# asp-net-core-mvc-template" 

# Add migration to apply changes

# Dublicate folder

if you get similar error:

C:\Users\nolimit-2\source\repos\ExamApplication\GameWebsite\Web\Areas\Administration\Controllers\PostAdministrationController.cs(26,13,26,25): warning CS0436: The type 'PostViewData' in 'C:\Users\nolimit-2\source\repos\ExamApplication\GameWebsite\Web\GameWebSite.Web.Models\PostViewData.cs' conflicts with the imported type 'PostViewData' in 'ExamApplication.Web.Models, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'. Using the type defined in 'C:\Users\nolimit-2\source\repos\ExamApplication\GameWebsite\Web\GameWebSite.Web.Models\PostViewData.cs'.

maybe there is problem with the web models - if so - remove WebModels from the Web project
