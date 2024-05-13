using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;
using Microsoft.Identity.Client.Extensions.Msal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using ZeeKer.DndTracker.Module.UseCases.ExecuteMultipleTransactionUseCase;

namespace ZeeKer.DndTracker.Module.BusinessObjects
{
    // Register this entity in your DbContext (usually in the BusinessObjects folder of your project) with the "public DbSet<MultipleTransaction> MultipleTransactions { get; set; }" syntax.
    //[DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("Name")]
    [XafDisplayName("������������� ���������")]
    [XafDefaultProperty(nameof(Reason))]
    public class MultipleTransaction : BaseObject
    {
        public MultipleTransaction()
        {
            // In the constructor, initialize collection properties, e.g.: 
            // this.AssociatedEntities = new ObservableCollection<AssociatedEntityObject>();
        }

        [XafDisplayName("�������")]
        public virtual string Reason { get; set; }

        [Browsable(false)]
        public virtual Guid? StorageSourceId {  get; set; }
        [XafDisplayName("��������� ��������"), ForeignKey(nameof(StorageSourceId))]
        public virtual CharacterStorage? StorageSource { get; set; }

        [XafDisplayName("��������� ����������"), Aggregated]
        public virtual IList<TransactionSettings> TransactionSettings { get; set; } = new ObservableCollection<TransactionSettings>();

        [XafDisplayName("��������� ���������"), NotMapped]
        public virtual IEnumerable<Character> ActiveCharacters => ObjectSpace.GetObjects<Character>(CriteriaOperator.Parse($"{nameof(Character.CampainId)} = ?", StorageSource?.Character?.CampainId));

        [XafDisplayName("����������� ��������"), Aggregated]
        public virtual IList<StorageOperation> StorageOperations { get; set; } = new ObservableCollection<StorageOperation>();

        // Alternatively, specify more UI options:
        //[XafDisplayName("My display name"), ToolTip("My hint message")]
        //[ModelDefault("EditMask", "(000)-00"), VisibleInListView(false)]
        //[RuleRequiredField(DefaultContexts.Save)]
        //public virtual string Name { get; set; }

        // Collection property:
        //public virtual IList<AssociatedEntityObject> AssociatedEntities { get; set; }

        [Action(Caption = "��������� ����������", ConfirmationMessage = "�� �������?", AutoCommit = true, SelectionDependencyType = MethodActionSelectionDependencyType.RequireSingleObject)]
        public void Execute()
        {
            var useCase = new ExecuteMultipleTransactionUseCase(ObjectSpace);

            useCase.Execute(this);
        }
    }
}