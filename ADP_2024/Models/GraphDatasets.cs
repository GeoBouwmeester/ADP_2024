namespace ADP_2024.Models;

public class GraphDatasets
{
    public List<List<int>> lijnlijst { get; set; }
    public List<List<int>> lijnlijst_gewogen { get; set; }
    public List<List<int>> verbindingslijst { get; set; }
    public List<List<List<int>>> verbindingslijst_gewogen { get; set; }
    public int[,] verbindingsmatrix { get; set; }
    public int[,] verbindingsmatrix_gewogen { get; set; }
}