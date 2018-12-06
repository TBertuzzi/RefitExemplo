using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Refit;
using RefitExemplo.Models;
using RefitExemplo.Services;

namespace RefitExemplo.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Property

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        public ObservableCollection<Usuario> Usuarios { get; }

        public MainViewModel()
        {
            Usuarios = new ObservableCollection<Usuario>();

            CarregaUsuarios();

        }

        private async Task CarregaUsuarios(List<Usuario> lista = null)
        {
            IsBusy = true;
            Usuarios.Clear();

            var usuarioAPI =  RestService.For<IRestApi>(EndPoints.BaseUrl);

            var usuariosRetorno = await usuarioAPI.GetTodos();

            foreach (var usuario in usuariosRetorno)
            {
                Usuarios.Add(usuario);
            }

           

             IsBusy = false;
        }

    }
}
