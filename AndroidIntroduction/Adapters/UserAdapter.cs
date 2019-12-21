using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using AndroidIntroduction.ViewHolder;

namespace AndroidIntroduction.Adapters
{
    public class UserAdapter : RecyclerView.Adapter
    {
        private List<User> _users;

        public UserAdapter(List<User> users)
        {
            _users = users;
        }

        public override int ItemCount => _users.Count;

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context)
                .Inflate(Resource.Layout.UserCardView, parent, false);
            UserViewHolder viewHolder = new UserViewHolder(itemView);
            return viewHolder;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var viewHolder = holder as UserViewHolder;
            viewHolder.TextViewName.Text = _users[position].Name;
            viewHolder.TextViewSurname.Text = _users[position].Surname;
        }

        
    }
}