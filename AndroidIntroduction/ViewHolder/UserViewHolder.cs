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

namespace AndroidIntroduction.ViewHolder
{
    public class UserViewHolder : RecyclerView.ViewHolder
    {
        public TextView TextViewName { get; set; }

        public TextView TextViewSurname { get; set; }

        public UserViewHolder(View itemView) : base(itemView)
        {
            TextViewName = itemView.FindViewById<TextView>(Resource.Id.textViewName);
            TextViewSurname = itemView.FindViewById<TextView>(Resource.Id.textViewSurname);
        }
    }
}