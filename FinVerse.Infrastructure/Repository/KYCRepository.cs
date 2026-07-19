using FinVerse.Infrastructure.Data;
using FinVerse.Infrastructure.Interface;
using FinVerse.Infrastructure.models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVerse.Infrastructure.Repository
{
    public class KYCRepository : IKYCRepository
    {
        private readonly IDBExecutor _dbexecutor;

        public KYCRepository(IDBExecutor dBExecutor)
        {
            _dbexecutor = dBExecutor;
        }
        public async Task<bool> UploadKycDetails(KYCDetailsEntity kycEntity, String KycStatus)
        {
            var parameter = new SqlParameter[]
                {
                    new SqlParameter("@UserId", kycEntity.UserId),
                    new SqlParameter("@KycId", kycEntity.KYCId),
                    new SqlParameter("@VerificationStatus", KycStatus),
                    new SqlParameter("@SubmittedAt", DateTime.UtcNow),
                    //new SqlParameter("@VerifiedAt", kycEntity.VerifiedAt),
                    new SqlParameter("@CustomerId", kycEntity.CustomerId),
                    new SqlParameter("@ImagePath", (object?)kycEntity.ImagePath ?? DBNull.Value),
                    new SqlParameter("@SignaturePath", (object?)kycEntity.SignaturePath ?? DBNull.Value),
                    new SqlParameter("@VoterIdPath", (object?)kycEntity.VoterIdPath ?? DBNull.Value),
                    new SqlParameter("@AadharPath", (object?)kycEntity.AadharPath ?? DBNull.Value),
                    new SqlParameter("@PanImagePath", (object?)kycEntity.PanImagePath ?? DBNull.Value),
                    new SqlParameter("@UserImageValid", (object?)kycEntity.UserImageValid ?? DBNull.Value),
                    new SqlParameter("@PanImageValid", (object?)kycEntity.PanImageValid ?? DBNull.Value),
                    new SqlParameter("@AadharValid", (object?)kycEntity.AadharValid ?? DBNull.Value),
                    new SqlParameter("@SignatureValid", (object?)kycEntity.SignatureValid ?? DBNull.Value),
                    new SqlParameter("@VoterValid", (object?)kycEntity.VoterValid ?? DBNull.Value),
                    new SqlParameter("@ModifiedBy", (object?)kycEntity.UserId ?? DBNull.Value),
                    new SqlParameter("@ModifiedOn", DateTime.UtcNow),
                    new SqlParameter("@Comments", (object?)kycEntity.Comments ?? DBNull.Value),


                };
            var result = await _dbexecutor.ExecuteNonQueryAsync("SP_InsertKYCDocument", parameter);
            return result > 0 ;
        }
    }
}
