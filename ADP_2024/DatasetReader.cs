using ADP_2024.Models;
using Newtonsoft.Json;

namespace ADP_2024;

public class DatasetReader
{
    private const string DATASET_PATH = "../../../../dataset_sorteren.json";
    private const string GRAPH_DATASET_PATH = "../../../../dataset_grafen.json";
	private const string DATASET_PATH_HASHING = "../../../../dataset_hashing.json";

	private Datasets Datasets { get; init; }
    public GraphDatasets GraphDatasets { get; init; }
	public HashingDatasets HashingDatasets { get; init; }

	public int[] LijstAflopend2 => Datasets.lijst_aflopend_2;
    public int[] LijstOplopend2 => Datasets.lijst_oplopend_2;
    public float[] LijstFloat8001 => Datasets.lijst_float_8001;
    public int[] LijstGesorteerdAflopend3 => Datasets.lijst_gesorteerd_aflopend_3;
    public int[] LijstGesorteerdOplopend3 => Datasets.lijst_gesorteerd_oplopend_3;
    public int[] LijstHerhaald1000 => Datasets.lijst_herhaald_1000;
    public int?[] LijstLeeg0 => Datasets.lijst_leeg_0;
    public int?[] LijstNull1 => Datasets.lijst_null_1;
    public int?[] LijstNull3 => Datasets.lijst_null_3;
    public object[] LijstOnsorteerbaar3 => Datasets.lijst_onsorteerbaar_3;
    public int[] LijstOplopend10000 => Datasets.lijst_oplopend_10000;
    public int[] LijstWillekeurig10000 => Datasets.lijst_willekeurig_10000;
    public int[] LijstWillekeurig3 => Datasets.lijst_willekeurig_3;
    public Pizza[] LijstPizza6 =>
    [
        new Pizza("A", 8),
        new Pizza("D", 8),
        new Pizza("E", 8),
        new Pizza("B", 8),
        new Pizza("C", 8),
        new Pizza("F", 8)
    ];

    public DatasetReader()
    {
        Datasets = Read();
        GraphDatasets = ReadGraphJson();
        HashingDatasets = ReadHashing();
    }

    private static Datasets Read()
    {
        using StreamReader r = new(DATASET_PATH);

        string json = r.ReadToEnd();

        return JsonConvert.DeserializeObject<Datasets>(json)!;
    }

    private static GraphDatasets ReadGraphJson()
    {
        using StreamReader r = new(GRAPH_DATASET_PATH);

        string json = r.ReadToEnd();

        return JsonConvert.DeserializeObject<GraphDatasets>(json)!;
    }

	private static HashingDatasets ReadHashing()
	{
		using StreamReader r = new(DATASET_PATH_HASHING);

		string json = r.ReadToEnd();

		return JsonConvert.DeserializeObject<HashingDatasets>(json)!;
	}
}
