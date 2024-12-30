using CommunityToolkit.Mvvm.Input;
using disaster_management.Models;
using disaster_management.ViewModels.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace disaster_management.ViewModels.ChildViewModels.Users
{
    public partial class UserViewModel
    {
        #region Properties

        private PaginationHelper<User> _Pagination_User;
        public PaginationHelper<User> Pagination_User
        {
            get => _Pagination_User;
            set => SetProperty(ref _Pagination_User, value);
        }



        private ObservableCollection<User>? _userList;
        public ObservableCollection<User>? UserList
        {
            get => _userList;
            set => SetProperty(ref _userList, value);
        }

        // Add
        private User _userAdd = new();
        public User UserAdd
        {
            get => _userAdd;
            set => SetProperty(ref _userAdd, value);
        }

        // Update
        private User _userUpdate = new();
        public User UserUpdate
        {
            get => _userUpdate;
            set => SetProperty(ref _userUpdate, value);
        }

        private User _selectedUser;
        public User SelectedUser
        {
            get => _selectedUser;
            set
            {
                SetProperty(ref _selectedUser, value);
                if (value != null)
                {
                    UserUpdate = value.Clone();

                    // ChangeStatusUpdate();
                }

            }
        }

        private ObservableCollection<UserGroup>? _groups;
        public ObservableCollection<UserGroup>? UserGroups
        {
            get => _groups;
            set
            {
                SetProperty(ref _groups, value);

            }
        }

        private UserGroup _selectedGroup;

        public UserGroup SelectedGroup
        {
            get { return _selectedGroup; }
            set { _selectedGroup = value; OnPropertyChanged(); }
        }


        private ObservableCollection<UserRole> _userRoles;

        public ObservableCollection<UserRole> UserRoles
        {
            get { return _userRoles; }
            set
            {
                if (_userRoles != value)
                {
                    _userRoles = value;
                    OnPropertyChanged();
                }
            }
        }


        private UserMembership _userMembership = new();

        public UserMembership UserMembership
        {
            get { return _userMembership; }
            set
            {
                if (_userMembership != value)
                {
                    _userMembership = value;
                    OnPropertyChanged();
                }
            }
        }
        private UserMembership _userMembershipUpdate;

        public UserMembership UserMembershipUpdate
        {
            get { return _userMembershipUpdate; }
            set
            {
                if (_userMembershipUpdate != value)
                {
                    _userMembershipUpdate = value;
                    OnPropertyChanged();
                }
            }
        }

        private UserMembership _userMembershipSelected;

        public UserMembership UserMembershipSelected
        {
            get { return _userMembershipSelected; }
            set
            {
                if (_userMembershipSelected != value)
                {
                    _userMembershipSelected = value;
                    OnPropertyChanged();
                }
            }
        }


        private int _SelectedGroupIndex;

        public int SelectedGroupIndex
        {
            get { return _SelectedGroupIndex; }
            set
            {
                if (_SelectedGroupIndex != value)
                {
                    _SelectedGroupIndex = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection< UserMembership > _userMembershipList;

        public ObservableCollection<UserMembership> UserMembershipList
        {
            get { return _userMembershipList; }
            set
            {
                if (_userMembershipList != value)
                {
                    _userMembershipList = value;
                    OnPropertyChanged();
                }
            }
        }


        //Command User
        public IAsyncRelayCommand LoadUserCommand { get; }
        public IAsyncRelayCommand AddUserCommand { get; }
        public IAsyncRelayCommand UpdateUserCommand { get; }
        public IAsyncRelayCommand DeleteUserCommand { get; }



        //Command User Member Ship
        public IAsyncRelayCommand LoadUserMemCommand { get; }
        public IAsyncRelayCommand AddUserMemCommand { get; }
        public IAsyncRelayCommand UpdateUserMemCommand { get; }
        public IAsyncRelayCommand DeleteUserMemCommand { get; }






        //Read
        public async Task LoadAllUser()
        {
            UserList = new ObservableCollection<User>(await userService.GetAllAsync());
        }

        //Add 
        public async Task AddUserAsync()
        {
            try
            {
                await userService.AddAsync(UserAdd.Clone());
                await LoadAllUser();
            }
            catch (Exception)
            {
            }
         
        }
        // Delete
        private async Task DelUser()
        {
            try
            {
                await userService.DeleteAsync(SelectedUser.UserId);
                await LoadAllUser();
            }
            catch (Exception)
            {
            }
          
        }
        //Update
        private async Task UpdateUser()
        {
            await userService.UpdateAsync(UserUpdate.Clone());
            await LoadAllUser();
        }

        #region Membership

        private async Task LoadMemberShip()
        {
            UserMembershipList = new ObservableCollection<UserMembership>(
                await userService.GetAllMembership());
        }

        private async Task AddMembership()
        {
            if (SelectedGroupIndex == 0)
            {
                UserMembership.GroupId = 1;
            }
            else if (SelectedGroupIndex == 1)
            {
                UserMembership.GroupId = 2;
            }
            else if (SelectedGroupIndex == 2)
            {
                UserMembership.GroupId = 3;
            }
            try
            {
                await userService.AddMembership(UserMembership.Clone());
                await LoadMemberShip();
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể thêm quyển, quyền lặp lại !");
            }
          
        }

        private async Task UpdateMembership()
        {
            await userService.UpdateMembership(UserMembershipUpdate.Clone());
           await LoadMemberShip();
        }

        private async Task DeleteMembership()
        {
            try
            {
                await userService.DeleteMembership(UserMembershipSelected.UserId);
                await LoadMemberShip();
            }
            catch (Exception)
            {
            }
           
        }

        #endregion



        #endregion Properties

    }
}
