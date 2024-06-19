using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZeeKer.DndTracker.Module.Migrations
{
    /// <inheritdoc />
    public partial class NewAssociationMethod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Campains_CampainId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_MultipleTransaction_CharacterStorages_StorageSourceId",
                table: "MultipleTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionPolicyActionPermissionObject_PermissionPolicyRoleBase_RoleID",
                table: "PermissionPolicyActionPermissionObject");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionPolicyMemberPermissionsObject_PermissionPolicyTypePermissionObject_TypePermissionObjectID",
                table: "PermissionPolicyMemberPermissionsObject");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionPolicyNavigationPermissionObject_PermissionPolicyRoleBase_RoleID",
                table: "PermissionPolicyNavigationPermissionObject");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionPolicyObjectPermissionsObject_PermissionPolicyTypePermissionObject_TypePermissionObjectID",
                table: "PermissionPolicyObjectPermissionsObject");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionPolicyTypePermissionObject_PermissionPolicyRoleBase_RoleID",
                table: "PermissionPolicyTypePermissionObject");

            migrationBuilder.DropForeignKey(
                name: "FK_StateMachineAppearances_StateMachineStates_StateID",
                table: "StateMachineAppearances");

            migrationBuilder.DropForeignKey(
                name: "FK_StateMachineTransitions_StateMachineStates_SourceStateID",
                table: "StateMachineTransitions");

            migrationBuilder.DropForeignKey(
                name: "FK_StorageOperations_MultipleTransaction_MultiTransactionId",
                table: "StorageOperations");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionSettings_MultipleTransaction_TransactionId",
                table: "TransactionSettings");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Campains_CampainId",
                table: "Characters",
                column: "CampainId",
                principalTable: "Campains",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MultipleTransaction_CharacterStorages_StorageSourceId",
                table: "MultipleTransaction",
                column: "StorageSourceId",
                principalTable: "CharacterStorages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionPolicyActionPermissionObject_PermissionPolicyRoleBase_RoleID",
                table: "PermissionPolicyActionPermissionObject",
                column: "RoleID",
                principalTable: "PermissionPolicyRoleBase",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionPolicyMemberPermissionsObject_PermissionPolicyTypePermissionObject_TypePermissionObjectID",
                table: "PermissionPolicyMemberPermissionsObject",
                column: "TypePermissionObjectID",
                principalTable: "PermissionPolicyTypePermissionObject",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionPolicyNavigationPermissionObject_PermissionPolicyRoleBase_RoleID",
                table: "PermissionPolicyNavigationPermissionObject",
                column: "RoleID",
                principalTable: "PermissionPolicyRoleBase",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionPolicyObjectPermissionsObject_PermissionPolicyTypePermissionObject_TypePermissionObjectID",
                table: "PermissionPolicyObjectPermissionsObject",
                column: "TypePermissionObjectID",
                principalTable: "PermissionPolicyTypePermissionObject",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionPolicyTypePermissionObject_PermissionPolicyRoleBase_RoleID",
                table: "PermissionPolicyTypePermissionObject",
                column: "RoleID",
                principalTable: "PermissionPolicyRoleBase",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StateMachineAppearances_StateMachineStates_StateID",
                table: "StateMachineAppearances",
                column: "StateID",
                principalTable: "StateMachineStates",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StateMachineTransitions_StateMachineStates_SourceStateID",
                table: "StateMachineTransitions",
                column: "SourceStateID",
                principalTable: "StateMachineStates",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StorageOperations_MultipleTransaction_MultiTransactionId",
                table: "StorageOperations",
                column: "MultiTransactionId",
                principalTable: "MultipleTransaction",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionSettings_MultipleTransaction_TransactionId",
                table: "TransactionSettings",
                column: "TransactionId",
                principalTable: "MultipleTransaction",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Campains_CampainId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_MultipleTransaction_CharacterStorages_StorageSourceId",
                table: "MultipleTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionPolicyActionPermissionObject_PermissionPolicyRoleBase_RoleID",
                table: "PermissionPolicyActionPermissionObject");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionPolicyMemberPermissionsObject_PermissionPolicyTypePermissionObject_TypePermissionObjectID",
                table: "PermissionPolicyMemberPermissionsObject");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionPolicyNavigationPermissionObject_PermissionPolicyRoleBase_RoleID",
                table: "PermissionPolicyNavigationPermissionObject");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionPolicyObjectPermissionsObject_PermissionPolicyTypePermissionObject_TypePermissionObjectID",
                table: "PermissionPolicyObjectPermissionsObject");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionPolicyTypePermissionObject_PermissionPolicyRoleBase_RoleID",
                table: "PermissionPolicyTypePermissionObject");

            migrationBuilder.DropForeignKey(
                name: "FK_StateMachineAppearances_StateMachineStates_StateID",
                table: "StateMachineAppearances");

            migrationBuilder.DropForeignKey(
                name: "FK_StateMachineTransitions_StateMachineStates_SourceStateID",
                table: "StateMachineTransitions");

            migrationBuilder.DropForeignKey(
                name: "FK_StorageOperations_MultipleTransaction_MultiTransactionId",
                table: "StorageOperations");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionSettings_MultipleTransaction_TransactionId",
                table: "TransactionSettings");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Campains_CampainId",
                table: "Characters",
                column: "CampainId",
                principalTable: "Campains",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_MultipleTransaction_CharacterStorages_StorageSourceId",
                table: "MultipleTransaction",
                column: "StorageSourceId",
                principalTable: "CharacterStorages",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionPolicyActionPermissionObject_PermissionPolicyRoleBase_RoleID",
                table: "PermissionPolicyActionPermissionObject",
                column: "RoleID",
                principalTable: "PermissionPolicyRoleBase",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionPolicyMemberPermissionsObject_PermissionPolicyTypePermissionObject_TypePermissionObjectID",
                table: "PermissionPolicyMemberPermissionsObject",
                column: "TypePermissionObjectID",
                principalTable: "PermissionPolicyTypePermissionObject",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionPolicyNavigationPermissionObject_PermissionPolicyRoleBase_RoleID",
                table: "PermissionPolicyNavigationPermissionObject",
                column: "RoleID",
                principalTable: "PermissionPolicyRoleBase",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionPolicyObjectPermissionsObject_PermissionPolicyTypePermissionObject_TypePermissionObjectID",
                table: "PermissionPolicyObjectPermissionsObject",
                column: "TypePermissionObjectID",
                principalTable: "PermissionPolicyTypePermissionObject",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionPolicyTypePermissionObject_PermissionPolicyRoleBase_RoleID",
                table: "PermissionPolicyTypePermissionObject",
                column: "RoleID",
                principalTable: "PermissionPolicyRoleBase",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_StateMachineAppearances_StateMachineStates_StateID",
                table: "StateMachineAppearances",
                column: "StateID",
                principalTable: "StateMachineStates",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_StateMachineTransitions_StateMachineStates_SourceStateID",
                table: "StateMachineTransitions",
                column: "SourceStateID",
                principalTable: "StateMachineStates",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_StorageOperations_MultipleTransaction_MultiTransactionId",
                table: "StorageOperations",
                column: "MultiTransactionId",
                principalTable: "MultipleTransaction",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionSettings_MultipleTransaction_TransactionId",
                table: "TransactionSettings",
                column: "TransactionId",
                principalTable: "MultipleTransaction",
                principalColumn: "ID");
        }
    }
}
