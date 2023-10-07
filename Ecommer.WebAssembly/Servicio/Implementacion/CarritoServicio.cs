using Blazored.LocalStorage;
using Blazored.Toast.Services;
using Ecommerce.DTO;
using Ecommer.WebAssembly.Servicio.Contrato;

namespace Ecommer.WebAssembly.Servicio.Implementacion
{
    public class CarritoServicio :ICarritoServicio
    {

        private ILocalStorageService _localStorageService;
        private ISyncLocalStorageService _syncLocalStorageService;
        private IToastService _toasService;

        public CarritoServicio(
              ILocalStorageService localStorageService,
        ISyncLocalStorageService syncLocalStorageService,
        IToastService toasService
            )
        {
            _localStorageService = localStorageService;
            _syncLocalStorageService = syncLocalStorageService;
            _toasService = toasService;
        }

        public event Action MostrarItems;

        public async Task AgregarCarrito(CarritoDTO modelo)
        {
            try
            {
                var carrito = await _localStorageService.GetItemAsync<List<CarritoDTO>>("carrito");
                if (carrito == null)
                    carrito = new List<CarritoDTO>();

                var encontrado = carrito.FirstOrDefault(c => c.Producto.IdProducto == modelo.Producto.IdProducto);

                if (encontrado != null)
                    carrito.Remove(encontrado);

                carrito.Add(modelo);
                await _localStorageService.SetItemAsync("carrito", carrito);

                if (encontrado != null)
                    _toasService.ShowSuccess("Producto fue Agregado en carrito");
                else
                    _toasService.ShowSuccess("Producto fue Actualizado al carrito");

                MostrarItems.Invoke();
                 
            }
            catch
            {
                _toasService.ShowError("No se pudo agregar al carrito");
            }
        }

        public int CantidadProductos()
        {
            var carrito = _syncLocalStorageService.GetItem<List<CarritoDTO>>("carrito");
            return carrito == null ? 0 : carrito.Count;
        }

        public async Task<List<CarritoDTO>> DevolverCarrito()
        {
            var carrito = await _localStorageService.GetItemAsync<List<CarritoDTO>>("carrito");
            if (carrito == null)
                carrito = new List<CarritoDTO>();

            return carrito;
        }

        public async Task EliminarCarrito(int idProducto)
        {
            try
            {
                var carrito = await _localStorageService.GetItemAsync<List<CarritoDTO>>("carrito");
                if(carrito != null)
                {
                    var elemento = carrito.FirstOrDefault(c => c.Producto.IdProducto == idProducto);
                    if(elemento != null)
                    {
                        carrito.Remove(elemento);
                        await _localStorageService.SetItemAsync("carrito", carrito);
                        MostrarItems.Invoke();
                    }
                }
            }
            catch
            {

            }
        }

        public async Task LimpiarCarrito()
        {
            await _localStorageService.RemoveItemAsync("carrito");
            MostrarItems.Invoke();
        }

     
    }
}
