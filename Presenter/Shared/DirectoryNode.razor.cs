using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Presenter.Models;

namespace Presenter.Shared
{
    public partial class DirectoryNode
    {
        public event EventHandler<string> PreviewRequestedEvent;

        [Parameter] public DirectoryModel Directory { get; set; }

    }
}