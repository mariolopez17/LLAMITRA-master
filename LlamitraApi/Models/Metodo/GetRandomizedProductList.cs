using LlamitraApi.Models.Dtos.CourseDtos;

namespace LlamitraApi.Models.Metodo
{
    /*public class GetRandomizedProductList
    {
        public static List<PublicacionGetDto> GetRandomizedProductLista(List<PublicacionGetDto> products)
        {
            if (products == null || products.Count == 0)
                return new List<PublicacionGetDto>();

            Random rng = new Random();
            List<PublicacionGetDto> randomizedList = new List<PublicacionGetDto>(products);

            int n = randomizedList.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                PublicacionGetDto value = randomizedList[k];
                randomizedList[k] = randomizedList[n];
                randomizedList[n] = value;
            }

            return randomizedList;
        }
    }*/
}

