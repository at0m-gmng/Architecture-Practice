namespace GameResources.Scripts.Services
{
    public class AllServices
    {
        public static AllServices Container => instance ?? (instance = new AllServices());

        private static AllServices instance;

        public void RegisterSingle<TService>(TService implementation) where TService : IService 
            => Implementation<TService>.ServiceInstance = implementation;

        public TService Single<TService>() where TService : IService => Implementation<TService>.ServiceInstance;

        private  static class Implementation<TService> where TService : IService
        {
            public static TService ServiceInstance;
        }
    }
}