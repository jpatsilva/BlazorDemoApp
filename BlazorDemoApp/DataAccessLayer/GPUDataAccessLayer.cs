using BlazorDemoApp.Interface;
using BlazorDemoApp.Models;
using MongoDB.Driver;

namespace BlazorDemoApp.DataAccessLayer
{
	public class GPUDataAccessLayer : IGPU
	{
		private MongoClient mongoClient        = null;
		private IMongoDatabase MongoDatabase   = null;
		private IMongoCollection<GPU> GPUTable = null;

		public GPUDataAccessLayer()
		{
			mongoClient = new MongoClient("mongodb://localhost:27017");
			MongoDatabase = mongoClient.GetDatabase("GPUPerformanceAnalysisVisualization");
			GPUTable = MongoDatabase.GetCollection<GPU>("GPUs");
		}
		public async void AddGPU(GPU gpu)
		{
			try
			{
				await GPUTable.InsertOneAsync(gpu);	
			}
			catch(Exception) 
			{
				throw;
			}
		}

		public async void DeleteGPU(string gpuId)
		{
			try
			{
				await GPUTable.DeleteOneAsync(x => x.Id == gpuId);
			}
			catch (Exception) 
			{
				throw;
			}
		}

		public async Task<List<GPU>> GetAllGPUs()
		{
			try
			{
				var GPUs = GPUTable.Find(FilterDefinition<GPU>.Empty).ToListAsync();
				return await GPUs;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async void UpdateGPU(GPU gpu)
		{
			try
			{
				await GPUTable.ReplaceOneAsync(x => x.Id == gpu.Id, gpu);
			}
			catch (Exception) 
			{
				throw;
			}
		}
	}
}
