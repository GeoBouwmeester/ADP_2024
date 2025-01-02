using ADP_2024.Models;
using Newtonsoft.Json;

namespace ADP_2024;

public class HashingDatasetReader
{
	private const string DATASET_PATH_HASHING = "../../../../dataset_hashing.json";
	private HashingDatasets Datasets { get; init; }
	public Dictionary<string, List<int>> hashtabelsleutelswaardes => Datasets.hashtabelsleutelswaardes;

	public HashingDatasetReader()
	{
		Datasets = Read();
	}

	private static HashingDatasets Read()
	{
		using StreamReader r = new(DATASET_PATH_HASHING);

		string json = r.ReadToEnd();

		return JsonConvert.DeserializeObject<HashingDatasets>(json)!;
	}
}
