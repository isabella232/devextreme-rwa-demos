﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace service.Models
{
    public partial class RwaContext : DbContext
    {
        public RwaContext()
        {
        }

        public RwaContext(DbContextOptions<RwaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActivitiesList> ActivitiesLists { get; set; } = null!;
        public virtual DbSet<Activity> Activities { get; set; } = null!;
        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<Manager> Managers { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
        public virtual DbSet<MessagesList> MessagesLists { get; set; } = null!;
        public virtual DbSet<Note> Notes { get; set; } = null!;
        public virtual DbSet<NotesList> NotesLists { get; set; } = null!;
        public virtual DbSet<OpportunitiesList> OpportunitiesLists { get; set; } = null!;
        public virtual DbSet<Opportunity> Opportunities { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductsOpportunitiesList> ProductsOpportunitiesLists { get; set; } = null!;
        public virtual DbSet<State> States { get; set; } = null!;
        public virtual DbSet<Task> Tasks { get; set; } = null!;
        public virtual DbSet<TasksList> TasksLists { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=BABICH-AL-NB-10\\SQLEXPRESS;Database=Rwa;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActivitiesList>(entity =>
            {
                entity.ToTable("Activities_List");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.ActivityId).HasColumnName("Activity_id");

                entity.Property(e => e.ContactId).HasColumnName("Contact_id");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.ManagerId).HasColumnName("Manager_id");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.ActivitiesLists)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Activities_List_Activities");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.ActivitiesLists)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Activities_List_Contacts");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.ActivitiesLists)
                    .HasForeignKey(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Activities_List_Managers");
            });

            modelBuilder.Entity<Activity>(entity =>
            {
                entity.HasIndex(e => e.Id, "IX_Statuses");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Activity1)
                    .HasMaxLength(50)
                    .HasColumnName("Activity");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompanyId).HasColumnName("Company_Id");

                entity.Property(e => e.EmployeeAddress)
                    .HasMaxLength(255)
                    .HasColumnName("Employee_Address");

                entity.Property(e => e.EmployeeBirthDate)
                    .HasPrecision(0)
                    .HasColumnName("Employee_Birth_Date");

                entity.Property(e => e.EmployeeCity)
                    .HasMaxLength(255)
                    .HasColumnName("Employee_City");

                entity.Property(e => e.EmployeeDepartmentId).HasColumnName("Employee_Department_ID");

                entity.Property(e => e.EmployeeEmail)
                    .HasMaxLength(100)
                    .HasColumnName("Employee_Email");

                entity.Property(e => e.EmployeeFirstName)
                    .HasMaxLength(255)
                    .HasColumnName("Employee_First_Name");

                entity.Property(e => e.EmployeeFullName)
                    .HasMaxLength(255)
                    .HasColumnName("Employee_Full_Name");

                entity.Property(e => e.EmployeeHireDate)
                    .HasPrecision(0)
                    .HasColumnName("Employee_Hire_Date");

                entity.Property(e => e.EmployeeHomePhone)
                    .HasMaxLength(255)
                    .HasColumnName("Employee_Home_Phone");

                entity.Property(e => e.EmployeeLastName)
                    .HasMaxLength(255)
                    .HasColumnName("Employee_Last_Name");

                entity.Property(e => e.EmployeeMobilePhone)
                    .HasMaxLength(25)
                    .HasColumnName("Employee_Mobile_Phone");

                entity.Property(e => e.EmployeePersonalProfile).HasColumnName("Employee_Personal_Profile");

                entity.Property(e => e.EmployeePicture).HasColumnName("Employee_Picture");

                entity.Property(e => e.EmployeePrefix)
                    .HasMaxLength(5)
                    .HasColumnName("Employee_Prefix");

                entity.Property(e => e.EmployeeSkype)
                    .HasMaxLength(100)
                    .HasColumnName("Employee_Skype");

                entity.Property(e => e.EmployeeStateId).HasColumnName("Employee_State_ID");

                entity.Property(e => e.EmployeeStatus)
                    .HasMaxLength(25)
                    .HasColumnName("Employee_Status");

                entity.Property(e => e.EmployeeTitle)
                    .HasMaxLength(25)
                    .HasColumnName("Employee_Title");

                entity.Property(e => e.EmployeeZipcode).HasColumnName("Employee_Zipcode");

                entity.Property(e => e.ProbationReason).HasColumnName("Probation_Reason");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("SSMA_TimeStamp");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_Contacts_Companies");

                entity.HasOne(d => d.EmployeeState)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.EmployeeStateId)
                    .HasConstraintName("FK_Contacts_States");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EmployeeAddress)
                    .HasMaxLength(255)
                    .HasColumnName("Employee_Address");

                entity.Property(e => e.EmployeeBirthDate)
                    .HasPrecision(0)
                    .HasColumnName("Employee_Birth_Date");

                entity.Property(e => e.EmployeeCity)
                    .HasMaxLength(255)
                    .HasColumnName("Employee_City");

                entity.Property(e => e.EmployeeDepartmentId).HasColumnName("Employee_Department_ID");

                entity.Property(e => e.EmployeeEmail)
                    .HasMaxLength(100)
                    .HasColumnName("Employee_Email");

                entity.Property(e => e.EmployeeFirstName)
                    .HasMaxLength(255)
                    .HasColumnName("Employee_First_Name");

                entity.Property(e => e.EmployeeFullName)
                    .HasMaxLength(255)
                    .HasColumnName("Employee_Full_Name");

                entity.Property(e => e.EmployeeHireDate)
                    .HasPrecision(0)
                    .HasColumnName("Employee_Hire_Date");

                entity.Property(e => e.EmployeeHomePhone)
                    .HasMaxLength(255)
                    .HasColumnName("Employee_Home_Phone");

                entity.Property(e => e.EmployeeLastName)
                    .HasMaxLength(255)
                    .HasColumnName("Employee_Last_Name");

                entity.Property(e => e.EmployeeMobilePhone)
                    .HasMaxLength(25)
                    .HasColumnName("Employee_Mobile_Phone");

                entity.Property(e => e.EmployeePersonalProfile).HasColumnName("Employee_Personal_Profile");

                entity.Property(e => e.EmployeePicture).HasColumnName("Employee_Picture");

                entity.Property(e => e.EmployeePrefix)
                    .HasMaxLength(5)
                    .HasColumnName("Employee_Prefix");

                entity.Property(e => e.EmployeeSkype)
                    .HasMaxLength(100)
                    .HasColumnName("Employee_Skype");

                entity.Property(e => e.EmployeeStateId).HasColumnName("Employee_State_ID");

                entity.Property(e => e.EmployeeStatus)
                    .HasMaxLength(25)
                    .HasColumnName("Employee_Status");

                entity.Property(e => e.EmployeeTitle)
                    .HasMaxLength(25)
                    .HasColumnName("Employee_Title");

                entity.Property(e => e.EmployeeZipcode).HasColumnName("Employee_Zipcode");

                entity.Property(e => e.ProbationReason).HasColumnName("Probation_Reason");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("SSMA_TimeStamp");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Message1).HasColumnName("message");

                entity.Property(e => e.Subject)
                    .HasMaxLength(50)
                    .HasColumnName("subject");
            });

            modelBuilder.Entity<MessagesList>(entity =>
            {
                entity.ToTable("Messages_List");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.ManagerId).HasColumnName("manager_id");

                entity.Property(e => e.MessageId).HasColumnName("message_id");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.MessagesLists)
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("FK_Messages_List_Contacts");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.MessagesLists)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK_Messages_List_Managers");

                entity.HasOne(d => d.Message)
                    .WithMany(p => p.MessagesLists)
                    .HasForeignKey(d => d.MessageId)
                    .HasConstraintName("FK_Messages_List_Messages");
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Note1).HasColumnName("note");
            });

            modelBuilder.Entity<NotesList>(entity =>
            {
                entity.ToTable("Notes_List");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.ManagerId).HasColumnName("manager_id");

                entity.Property(e => e.NoteId).HasColumnName("note_id");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.NotesLists)
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("FK_Notes_List_Contacts");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.NotesLists)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK_Notes_List_Managers");

                entity.HasOne(d => d.Note)
                    .WithMany(p => p.NotesLists)
                    .HasForeignKey(d => d.NoteId)
                    .HasConstraintName("FK_Notes_List_Notes");
            });

            modelBuilder.Entity<OpportunitiesList>(entity =>
            {
                entity.ToTable("Opportunities_List");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.ManagerId).HasColumnName("manager_id");

                entity.Property(e => e.OpportunityId).HasColumnName("opportunity_id");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.OpportunitiesLists)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Oportunities_List_Oportunities_List");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.OpportunitiesLists)
                    .HasForeignKey(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Oportunities_List_Managers");

                entity.HasOne(d => d.Opportunity)
                    .WithMany(p => p.OpportunitiesLists)
                    .HasForeignKey(d => d.OpportunityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Oportunities_List_Opportunities");
            });

            modelBuilder.Entity<Opportunity>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Opportunity1)
                    .HasMaxLength(50)
                    .HasColumnName("Opportunity");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.Property(e => e.ProductCost)
                    .HasColumnType("money")
                    .HasColumnName("Product_Cost");

                entity.Property(e => e.ProductDescription).HasColumnName("Product_Description");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .HasColumnName("Product_Name");

                entity.Property(e => e.ProductRetailPrice)
                    .HasColumnType("money")
                    .HasColumnName("Product_Retail_Price");

                entity.Property(e => e.ProductSalePrice)
                    .HasColumnType("money")
                    .HasColumnName("Product_Sale_Price");
            });

            modelBuilder.Entity<ProductsOpportunitiesList>(entity =>
            {
                entity.ToTable("Products_Opportunities_List");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OpportunityListId).HasColumnName("opportunity_list_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.HasOne(d => d.OpportunityList)
                    .WithMany(p => p.ProductsOpportunitiesLists)
                    .HasForeignKey(d => d.OpportunityListId)
                    .HasConstraintName("FK_Products_Opportunities_List_Opportunities_List");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductsOpportunitiesLists)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Products_Opportunities_List_Products");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasKey(e => e.SateId);

                entity.Property(e => e.SateId).HasColumnName("Sate_ID");

                entity.Property(e => e.Flag24px).HasColumnName("Flag_24px");

                entity.Property(e => e.Flag48px).HasColumnName("Flag_48px");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("SSMA_TimeStamp");

                entity.Property(e => e.StateLong)
                    .HasMaxLength(255)
                    .HasColumnName("State_Long");

                entity.Property(e => e.StateShort)
                    .HasMaxLength(2)
                    .HasColumnName("State_Short");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Task1)
                    .HasMaxLength(50)
                    .HasColumnName("task")
                    .IsFixedLength();
            });

            modelBuilder.Entity<TasksList>(entity =>
            {
                entity.ToTable("Tasks_List");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.Done).HasColumnName("done");

                entity.Property(e => e.ManagerId).HasColumnName("manager_id");

                entity.Property(e => e.TaskId).HasColumnName("task_id");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.TasksLists)
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("FK_Tasks_List_Contacts");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.TasksLists)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK_Tasks_List_Managers");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.TasksLists)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("FK_Tasks_List_Tasks");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
