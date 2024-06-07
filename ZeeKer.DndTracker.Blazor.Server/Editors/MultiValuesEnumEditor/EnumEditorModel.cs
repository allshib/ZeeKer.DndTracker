using DevExpress.ExpressApp.Blazor.Components.Models;

namespace ZeeKer.DndTracker.Blazor.Server.Editors.MultiValuesEnumEditor
{
  
    public class EnumEditorModel : ComponentModelBase {
        public EnumEditorModel(List<MultiValuesEnumDescriptor> _source,Type propertyType) {
            DataSource = _source;
            //FieldName = _fieldName;
            PropertyType = propertyType;
        }

        public Type PropertyType {
            get => GetPropertyValue<Type>();
            set => SetPropertyValue(value);
        }

        //public object Value {
        //    get => GetPropertyValue<object>();
        //    set => SetPropertyValue(value);
        //}
        public bool ReadOnly {
            get => GetPropertyValue<bool>();
            set => SetPropertyValue(value);
        }
        //public string FieldName {
        //    get => GetPropertyValue<string>();
        //    set => SetPropertyValue(value);
        //}
        // ...
        public void SetValueFromUI(IEnumerable<int> value) {
            SetPropertyValue(value, notify: false, nameof(Values));
            ValueChanged?.Invoke(this, EventArgs.Empty);
        }
        public event EventHandler ValueChanged;

        public List<MultiValuesEnumDescriptor> DataSource {
            get => GetPropertyValue<List<MultiValuesEnumDescriptor>>();
            set => SetPropertyValue(value);
        }

        public IEnumerable<int> Values {
            get => GetPropertyValue<IEnumerable<int>>();
            set => SetPropertyValue(value);
        }
    }
}
