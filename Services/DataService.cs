using ManagerSalesTestProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerSalesTestProject.Services
{
    public class DataService
    {
        private readonly ManagerSalesTestProjectContext _context;

        public DataService(ManagerSalesTestProjectContext context)
        {
            _context = context;
        }

        // ��������� ����� ������������
        public async Task<List<EquipmentModel>> GetAllEquipmentAsync()
        {
            return await _context.Equipment.AsNoTracking().ToListAsync();
        }

        // ��������� ������������ �� ID
        public async Task<EquipmentModel> GetEquipmentByIdAsync(int id)
        {
            return await _context.Equipment.FindAsync(id);
        }

        // ���������� ������ ������������
        public async Task AddEquipmentAsync(EquipmentModel equipment)
        {
            _context.Equipment.Add(equipment);
            await _context.SaveChangesAsync();
        }

        // ����������
        public async Task UpdateEquipmentAsync(EquipmentModel equipment)
        {
            //FindAsync ��������� ��������, ������� ����������� ��������

            var exsitingEquipment = await GetEquipmentByIdAsync(equipment.Id);
            //�������� �� ������ � ������ �������������

            _context.Entry(exsitingEquipment).CurrentValues.SetValues(equipment);
            await _context.SaveChangesAsync();
        }

        // �������� 
        public async Task DeleteEquipmentAsync(int id)
        {
            var equipment = await _context.Equipment.FindAsync(id);
            if (equipment != null)
                _context.Equipment.Remove(equipment);
            await _context.SaveChangesAsync();
        }

        // �� �������  (�� ������ )
        public async Task<List<EquipmentModel>> GetEquipmentByStatusAsync(EquipmentStatus status)
        {
            return await _context.Equipment
                .AsNoTracking()
                .Where(e => e.Status == status)
                .ToListAsync();
        }

        //  �� ���� (�� ������)
        public async Task<List<EquipmentModel>> GetEquipmentByTypeAsync(EquipmentType type)
        {
            return await _context.Equipment
                .AsNoTracking()
                .Where(e => e.Type == type)
                .ToListAsync();
        }
    }
}