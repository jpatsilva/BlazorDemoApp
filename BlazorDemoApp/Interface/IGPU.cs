using BlazorDemoApp.Models;

namespace BlazorDemoApp.Interface
{
	public interface IGPU
	{
		public Task<List<GPU>> GetAllGPUs();
		public void AddGPU(GPU gpu);
		public void UpdateGPU(GPU gpu);
		public void DeleteGPU(string  gpuId);
	}
}
