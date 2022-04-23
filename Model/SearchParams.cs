using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smev_Bot.Model
{
    public enum Zone
    {
        UnknowZone,
        Fed,
        Reg,
    }

    public class SearchParams
    {
        public string name { get; set; }
        public string application { get; set; }
        public Zone zone { get; set; }
        public bool displayProdRequest { get; set; }
        public bool displayTestRequest { get; set; }

        public string version { get; set; }
        public string id { get; set; }
        public string subject { get; set; }
        public string serviceOwner { get; set; }

        public SearchParams()
        {
            name = "";
            application = "";
            zone = Zone.UnknowZone;
            displayProdRequest = false;
            displayTestRequest = false;

            version = "";
            id = "";
            subject = "";
            serviceOwner = "";
        }
    }

    public class Commands : Collection<ISearchParamsCommand> { }

    internal class SearchParamsMaker
    {
        Commands commands = new Commands();
        public void AddCommand(ISearchParamsCommand command) => commands.Add(command);
        public void ExecuteLast()
        {
            commands.Where(c => !c.IsComplite)
                    .ToList()
                    .ForEach(c => c.Execute());
        }
        public void UndoLast() 
        {
            commands.Last().Undo();
        }
    }

    public interface ISearchParamsCommand
    {
        public bool IsComplite { get; }
        public void Execute();
        public void Undo();
    }

    namespace SearchParamsCommand
    {
        public class SetName : ISearchParamsCommand
        {
            bool isComplite;
            public bool IsComplite { get { return isComplite; } }

            string name;
            SearchParams searchParams;

            public SetName(string name, SearchParams searchParams)
            {
                this.searchParams = searchParams;
                this.name = name;
            }

            public void Execute()
            {
                if (isComplite) return;
                searchParams.name = name;
                isComplite = true;
            }

            public void Undo()
            {
                if (!isComplite) return;
                searchParams.name = "";
                isComplite = false;
            }
        }
        public class SetApplication : ISearchParamsCommand
        {
            bool isComplite;
            public bool IsComplite { get { return isComplite; } }

            string application;
            SearchParams searchParams;

            public SetApplication(string application, SearchParams searchParams)
            {
                this.searchParams = searchParams;
                this.application = application;
            }

            public void Execute()
            {
                if (isComplite) return;
                searchParams.application = application;
                isComplite = true;
            }

            public void Undo()
            {
                if (!isComplite) return;
                searchParams.application = "";
                isComplite = false;
            }
        }
        public class SetZone : ISearchParamsCommand
        {
            bool isComplite;
            public bool IsComplite { get { return isComplite; } }

            Zone zone;
            SearchParams searchParams;

            public SetZone(Zone zone, SearchParams searchParams)
            {
                this.searchParams = searchParams;
                this.zone = zone;
            }

            public void Execute()
            {
                if (isComplite) return;
                searchParams.zone = zone;
                isComplite = true;
            }

            public void Undo()
            {
                if (!isComplite) return;
                searchParams.zone = Zone.UnknowZone;
                isComplite = false;
            }
        }
        public class SetDisplayProdRequest : ISearchParamsCommand
        {
            bool isComplite;
            public bool IsComplite { get { return isComplite; } }

            bool displayProdRequest;
            SearchParams searchParams;

            public SetDisplayProdRequest(bool displayProdRequest, SearchParams searchParams)
            {
                this.searchParams = searchParams;
                this.displayProdRequest = displayProdRequest;
            }

            public void Execute()
            {
                if (isComplite) return;
                searchParams.displayProdRequest = displayProdRequest;
                isComplite = true;
            }

            public void Undo()
            {
                if (!isComplite) return;
                searchParams.displayProdRequest = false;
                isComplite = false;
            }
        }
        public class SetDisplayTestRequest : ISearchParamsCommand
        {
            bool isComplite;
            public bool IsComplite { get { return isComplite; } }

            bool displayTestRequest;
            SearchParams searchParams;

            public SetDisplayTestRequest(bool displayTestRequest, SearchParams searchParams)
            {
                this.searchParams = searchParams;
                this.displayTestRequest = displayTestRequest;
            }

            public void Execute()
            {
                if (isComplite) return;
                searchParams.displayTestRequest = displayTestRequest;
                isComplite = true;
            }

            public void Undo()
            {
                if (!isComplite) return;
                searchParams.displayTestRequest = false;
                isComplite = false;
            }
        }
        public class SetVersion : ISearchParamsCommand
        {
            bool isComplite;
            public bool IsComplite { get { return isComplite; } }

            string version;
            SearchParams searchParams;

            public SetVersion(string version, SearchParams searchParams)
            {
                this.searchParams = searchParams;
                this.version = version;
            }

            public void Execute()
            {
                if (isComplite) return;
                searchParams.version = version;
                isComplite = true;
            }

            public void Undo()
            {
                if (!isComplite) return;
                searchParams.version = "";
                isComplite = false;
            }
        }
        public class SetId : ISearchParamsCommand
        {
            bool isComplite;
            public bool IsComplite { get { return isComplite; } }

            string id;
            SearchParams searchParams;

            public SetId(string id, SearchParams searchParams)
            {
                this.searchParams = searchParams;
                this.id = id;
            }

            public void Execute()
            {
                if (isComplite) return;
                searchParams.id = id;
                isComplite = true;
            }

            public void Undo()
            {
                if (!isComplite) return;
                searchParams.id = "";
                isComplite = false;
            }
        }
        public class SetSubject : ISearchParamsCommand
        {
            bool isComplite;
            public bool IsComplite { get { return isComplite; } }

            string subject;
            SearchParams searchParams;

            public SetSubject(string subject, SearchParams searchParams)
            {
                this.searchParams = searchParams;
                this.subject = subject;
            }

            public void Execute()
            {
                if (isComplite) return;
                searchParams.subject = subject;
                isComplite = true;
            }

            public void Undo()
            {
                if (!isComplite) return;
                searchParams.subject = "";
                isComplite = false;
            }
        }
        public class SetServiceOwner : ISearchParamsCommand
        {
            bool isComplite;
            public bool IsComplite { get { return isComplite; } }

            string serviceOwner;
            SearchParams searchParams;

            public SetServiceOwner(string serviceOwner, SearchParams searchParams)
            {
                this.searchParams = searchParams;
                this.serviceOwner = serviceOwner;
            }

            public void Execute()
            {
                if (isComplite) return;
                searchParams.serviceOwner = serviceOwner;
                isComplite = true;
            }

            public void Undo()
            {
                if (!isComplite) return;
                searchParams.serviceOwner = "";
                isComplite = false;
            }
        }
    }



}
