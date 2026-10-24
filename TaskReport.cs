// Regras do relatório de tarefas, separadas do Program.cs para poderem ser testadas
public static class TaskReport
{
    public const string Title = "TaskTracker";
    public const string DoneMarker = "(done)";
    public const string ClosingMessage = "Keep going!";

    // Uma tarefa está concluída quando termina com o marcador (done)
    public static bool IsDone(string task) =>
        task.EndsWith(DoneMarker);

    // Mantém apenas as tarefas pendentes, na ordem original
    public static List<string> GetPending(IEnumerable<string> tasks) =>
        tasks.Where(task => !IsDone(task)).ToList();

    // Monta as linhas exibidas no terminal
    public static List<string> Render(IEnumerable<string> tasks)
    {
        var pending = GetPending(tasks);
        var lines = new List<string>
        {
            Title,
            $"Pending tasks: {pending.Count}"
        };

        for (var i = 0; i < pending.Count; i++)
            lines.Add($"{i + 1}. {pending[i]}");

        lines.Add(ClosingMessage);
        return lines;
    }
}
