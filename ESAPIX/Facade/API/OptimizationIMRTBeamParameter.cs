#region

using System.Dynamic;
using X = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class OptimizationIMRTBeamParameter : OptimizationParameter
    {
        public OptimizationIMRTBeamParameter()
        {
            _client = new ExpandoObject();
        }

        public OptimizationIMRTBeamParameter(dynamic client)
        {
            _client = client;
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client); }
        }

        public Beam Beam
        {
            get
            {
                if (_client is ExpandoObject) return _client.Beam;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.Beam)) return default(Beam);
                    return new Beam(local._client.Beam);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.Beam = value;
            }
        }

        public string BeamId
        {
            get
            {
                if (_client is ExpandoObject) return _client.BeamId;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.BeamId; });
            }
            set
            {
                if (_client is ExpandoObject) _client.BeamId = value;
            }
        }

        public bool Excluded
        {
            get
            {
                if (_client is ExpandoObject) return _client.Excluded;
                var local = this;
                return X.Instance.CurrentContext.GetValue<bool>(sc => { return local._client.Excluded; });
            }
            set
            {
                if (_client is ExpandoObject) _client.Excluded = value;
            }
        }

        public bool FixedJaws
        {
            get
            {
                if (_client is ExpandoObject) return _client.FixedJaws;
                var local = this;
                return X.Instance.CurrentContext.GetValue<bool>(sc => { return local._client.FixedJaws; });
            }
            set
            {
                if (_client is ExpandoObject) _client.FixedJaws = value;
            }
        }

        public double SmoothX
        {
            get
            {
                if (_client is ExpandoObject) return _client.SmoothX;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.SmoothX; });
            }
            set
            {
                if (_client is ExpandoObject) _client.SmoothX = value;
            }
        }

        public double SmoothY
        {
            get
            {
                if (_client is ExpandoObject) return _client.SmoothY;
                var local = this;
                return X.Instance.CurrentContext.GetValue<double>(sc => { return local._client.SmoothY; });
            }
            set
            {
                if (_client is ExpandoObject) _client.SmoothY = value;
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}