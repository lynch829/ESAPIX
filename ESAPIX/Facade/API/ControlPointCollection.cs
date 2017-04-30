#region

using System.Dynamic;
using X = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class ControlPointCollection : SerializableObject
    {
        public ControlPointCollection()
        {
            _client = new ExpandoObject();
        }

        public ControlPointCollection(dynamic client)
        {
            _client = client;
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client); }
        }

        public ControlPoint this[int index]
        {
            get
            {
                if (_client is ExpandoObject) return _client[index];
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client[index])) return default(ControlPoint);
                    return new ControlPoint(local._client[index]);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client[index] = value;
            }
        }

        public int Count
        {
            get
            {
                if (_client is ExpandoObject) return _client.Count;
                var local = this;
                return X.Instance.CurrentContext.GetValue<int>(sc => { return local._client.Count; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Count = value;
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}