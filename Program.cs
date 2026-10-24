// Lista inicial de tarefas do TaskTracker
var tasks = new List<string>
{
    "[High] Install Git (done)",
    "[High] Configure user name and email (done)",
    "[Medium] Create the first repository (done)",
    "[Low] Learn about remotes"
};

foreach (var line in TaskReport.Render(tasks))
    Console.WriteLine(line);
