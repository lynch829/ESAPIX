#region

using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class Series : ApiDataObject
    {
        public Series()
        {
            _client = new ExpandoObject();
        }

        public Series(dynamic client)
        {
            _client = client;
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client); }
        }

        public string FOR
        {
            get
            {
                if (_client is ExpandoObject) return _client.FOR;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.FOR; });
            }
            set
            {
                if (_client is ExpandoObject) _client.FOR = value;
            }
        }

        public IEnumerable<Image> Images
        {
            get
            {
                IEnumerator enumerator = null;
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    var asEnum = (IEnumerable) _client.Images;
                    enumerator = asEnum.GetEnumerator();
                });
                while (X.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                {
                    var facade = new Image();
                    X.Instance.CurrentContext.Thread.Invoke(() =>
                    {
                        var vms = enumerator.Current;
                        if (vms != null)
                            facade._client = vms;
                    });
                    if (facade._client != null)
                        yield return facade;
                }
            }
        }

        public string ImagingDeviceId
        {
            get
            {
                if (_client is ExpandoObject) return _client.ImagingDeviceId;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.ImagingDeviceId; });
            }
            set
            {
                if (_client is ExpandoObject) _client.ImagingDeviceId = value;
            }
        }

        public string ImagingDeviceManufacturer
        {
            get
            {
                if (_client is ExpandoObject) return _client.ImagingDeviceManufacturer;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc =>
                {
                    return local._client.ImagingDeviceManufacturer;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.ImagingDeviceManufacturer = value;
            }
        }

        public string ImagingDeviceModel
        {
            get
            {
                if (_client is ExpandoObject) return _client.ImagingDeviceModel;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.ImagingDeviceModel; });
            }
            set
            {
                if (_client is ExpandoObject) _client.ImagingDeviceModel = value;
            }
        }

        public string ImagingDeviceSerialNo
        {
            get
            {
                if (_client is ExpandoObject) return _client.ImagingDeviceSerialNo;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc =>
                {
                    return local._client.ImagingDeviceSerialNo;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.ImagingDeviceSerialNo = value;
            }
        }

        public Types.SeriesModality Modality
        {
            get
            {
                if (_client is ExpandoObject) return _client.Modality;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    return (Types.SeriesModality) local._client.Modality;
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.Modality = value;
            }
        }

        public Study Study
        {
            get
            {
                if (_client is ExpandoObject) return _client.Study;
                var local = this;
                return X.Instance.CurrentContext.GetValue(sc =>
                {
                    if (DefaultHelper.IsDefault(local._client.Study)) return default(Study);
                    return new Study(local._client.Study);
                });
            }
            set
            {
                if (_client is ExpandoObject) _client.Study = value;
            }
        }

        public string UID
        {
            get
            {
                if (_client is ExpandoObject) return _client.UID;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.UID; });
            }
            set
            {
                if (_client is ExpandoObject) _client.UID = value;
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            var local = this;
            X.Instance.CurrentContext.Thread.Invoke(() => { local._client.WriteXml(writer); });
        }
    }
}