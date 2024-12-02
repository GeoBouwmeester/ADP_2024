using ADP_2024.Models;
using Newtonsoft.Json;

namespace ADP_2024;

public class DatasetReader
{
    private const string DATASET_PATH = "../../../../ADP_2024/resources/dataset_sorteren.json";
    private Datasets Datasets { get; init; }

    public int[] LijstAflopend2 => Datasets.lijst_aflopend_2;
    public object[] LijstOnsorteerbaar3 => Datasets.lijst_onsorteerbaar_3;
    public int[] LijstWillekeurig10000 => Datasets.lijst_willekeurig_10000;
    public int[] LijstOplopend10000 => Datasets.lijst_oplopend_10000;
    public Pizza[] LijstPizza6 =>
    [
        new Pizza("Pepperoni", 8),
        new Pizza("Pepperoni", 6),
        new Pizza("Mozzarella", 8),
        new Pizza("Mozzarella", 6),
        new Pizza("Margherita", 8),
        new Pizza("Margherita", 6)
    ];

    public DatasetReader()
    {
        Datasets = Read();
    }

    private static Datasets Read()
    {
        using StreamReader r = new(DATASET_PATH);

        string json = r.ReadToEnd();

        return JsonConvert.DeserializeObject<Datasets>(json)!;
    }
}
