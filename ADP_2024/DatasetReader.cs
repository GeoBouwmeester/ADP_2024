using ADP_2024.Models;
using Newtonsoft.Json;

namespace ADP_2024;

public class DatasetReader
{
    private const string DATASET_PATH = "../../../../ADP_2024/resources/dataset_sorteren.json";
    private Datasets Datasets { get; init; }

    public int[] LijstAflopend2 => Datasets.lijst_aflopend_2;
    public int[] LijstOplopend2 => Datasets.lijst_oplopend_2;
    public float[] LijstFloat8001 => Datasets.lijst_float_8001;
    public int[] LijstGesorteerdAflopend3 => Datasets.lijst_gesorteerd_aflopend_3;
    public int[] LijstGesorteerdOplopend3 => Datasets.lijst_gesorteerd_oplopend_3;
    public int[] LijstHerhaald1000 => Datasets.lijst_herhaald_1000;
    public object[] LijstLeeg0 => Datasets.lijst_leeg_0;
    public object[] LijstNull1 => Datasets.lijst_null_1;
    public object[] LijstNull3 => Datasets.lijst_null_3;
    public object[] LijstOnsorteerbaar3 => Datasets.lijst_onsorteerbaar_3;
    public int[] LijstOplopend10000 => Datasets.lijst_oplopend_10000;
    public int[] LijstWillekeurig10000 => Datasets.lijst_willekeurig_10000;
    public int[] LijstWillekeurig3 => Datasets.lijst_willekeurig_3;
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
