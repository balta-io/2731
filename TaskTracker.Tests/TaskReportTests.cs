public class TaskReportTests
{
    [Theory]
    [InlineData("[High] Install Git (done)", true)]
    [InlineData("[Low] Learn about remotes", false)]
    [InlineData("(done) is only valid at the end", false)]
    public void IsDone_ChecksTheDoneMarkerAtTheEnd(string task, bool expected)
    {
        Assert.Equal(expected, TaskReport.IsDone(task));
    }

    [Fact]
    public void GetPending_RemovesDoneTasksAndKeepsOrder()
    {
        var tasks = new List<string>
        {
            "[High] Install Git (done)",
            "[Medium] Write the README",
            "[Low] Learn about remotes"
        };

        var pending = TaskReport.GetPending(tasks);

        var expected = new List<string> { "[Medium] Write the README", "[Low] Learn about remotes" };

        Assert.Equal(expected, pending);
    }

    [Fact]
    public void GetPending_ReturnsEmptyListWhenAllTasksAreDone()
    {
        var tasks = new List<string> { "[High] Install Git (done)" };

        Assert.Empty(TaskReport.GetPending(tasks));
    }

    [Fact]
    public void Render_ShowsTitleCountNumberedTasksAndClosingMessage()
    {
        var tasks = new List<string>
        {
            "[High] Install Git (done)",
            "[Medium] Write the README",
            "[Low] Learn about remotes"
        };

        var lines = TaskReport.Render(tasks);

        var expected = new List<string>
        {
            "TaskTracker",
            "Pending tasks: 2",
            "1. [Medium] Write the README",
            "2. [Low] Learn about remotes",
            "Keep going!"
        };

        Assert.Equal(expected, lines);
    }

    [Fact]
    public void Render_WithNoPendingTasks_ShowsZeroAndClosingMessage()
    {
        var lines = TaskReport.Render(new List<string>());

        var expected = new List<string> { "TaskTracker", "Pending tasks: 0", "Keep going!" };

        Assert.Equal(expected, lines);
    }
}
