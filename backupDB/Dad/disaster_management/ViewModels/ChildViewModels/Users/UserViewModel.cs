using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using disaster_management.Models;
using disaster_management.Services;
using disaster_management.ViewModels.Utils;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace disaster_management.ViewModels.ChildViewModels.Users
{
   public partial class UserViewModel : ObservableObject
    {
        private readonly IUserService userService;
        private readonly IUserGroupService userGroupService;
        private readonly IUserRoleService userRoleService;
        private readonly IUserLogService userLogService;

        public IAsyncRelayCommand LoadCurrentUserCommand;

        public UserViewModel(IUserService userService,IUserGroupService userGroupService, IUserRoleService userRoleService, IUserLogService userLogService)
        {
            this.userService = userService;
            this.userGroupService = userGroupService;
            this.userRoleService = userRoleService;
            this.userLogService = userLogService;
            LoadCurrentUserCommand = new AsyncRelayCommand(LoadCurrentUserAsync);



            //Command User
            LoadUserCommand = new AsyncRelayCommand(LoadAllUser);
            AddUserCommand  = new AsyncRelayCommand(AddUserAsync);
            UpdateUserCommand = new AsyncRelayCommand(UpdateUser);
            DeleteUserCommand = new AsyncRelayCommand(DelUser);



            ////Command User Member Ship
            LoadUserMemCommand = new AsyncRelayCommand(LoadMemberShip);
            AddUserMemCommand = new AsyncRelayCommand(AddMembership);
            UpdateUserMemCommand = new AsyncRelayCommand(UpdateMembership);
            DeleteUserMemCommand = new AsyncRelayCommand(DeleteMembership);
           

            LoadListAsync();

        }

        private async void LoadListAsync()
        {
            await LoadUserCommand.ExecuteAsync(null);
            await LoadCurrentUserCommand.ExecuteAsync(null);
            await LoadUserMemCommand.ExecuteAsync(null);
        }

        private async Task LoadCurrentUserAsync()
        {
            CurrentUser = await userService.ValidateUser(GlobalVariables.Username, GlobalVariables.Password);
        }

        
       

        private User _user = new();
        public User CurrentUser
        {
            get { return _user; }
            set { _user = value; 
                OnPropertyChanged();
                if (_user != null)
                    UserRole = CurrentUser.Groups.FirstOrDefault().Roles.FirstOrDefault();

            }
        }

        private UserRole _ur;

        public UserRole UserRole
        {
            get { return _ur; }
            set { _ur = value; OnPropertyChanged(); }
        }





    }
}
