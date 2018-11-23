using BTS.SICEP.Biometria.Entidades;
using Neurotec.Biometrics;
using Neurotec.Biometrics.Client;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BTS.SICEP.WCF.BiometriaService
{
    public class BiometriaBuscador
    {
        private NBiometricClient _biometricClient;
        private string _connStr;
        private const short DERECHO = 1;

        public BiometriaBuscador()
        {
            _connStr = ObtenerConexion();
            _biometricClient = new NBiometricClient { UseDeviceManager = true, BiometricTypes = NBiometricType.Finger | NBiometricType.Face | NBiometricType.Iris | NBiometricType.Voice };
        }

        public async Task<VerificarHuellaInfo> BuscarHuellaEnTemplates(NSubject subjectBuscar, int idBusqueda)
        {
            #region BuscarHuellaEnTemplates
            var select = "SELECT ESTADO,MUNICIPIO,CERESO,ANO,FOLIO,DEDO,HUELLAIMAGEN,TEMPLATE FROM BTS.HUELLA ";
            var conn = new OracleConnection(_connStr);
            var template = new byte[] { };
            var subject = new NSubject();
            var finger = new NFinger();
            var _verificarHuellaInfo = new VerificarHuellaInfo();


            try
            {
                await conn.OpenAsync();

                var cmdSelect = new OracleCommand(select, conn);
                var dr = await cmdSelect.ExecuteReaderAsync();

                while (await dr.ReadAsync())
                {
                    if (dr.IsDBNull(6) == false)
                    {
                        template = (byte[])dr[6];

                        finger = new NFinger();
                        finger.SampleBuffer = new Neurotec.IO.NBuffer(template);

                        subject = new NSubject();
                        subject.Fingers.Add(finger);

                        var status = await _biometricClient.VerifyAsync(subject, subjectBuscar);

                        var verificationStatus = string.Format("Verification status: {0}", status);

                        if (status == NBiometricStatus.Ok)
                        {
                            _verificarHuellaInfo.Identificado = true;
                            _verificarHuellaInfo.PersonaIdentificar.id = idBusqueda;
                            _verificarHuellaInfo.PersonaIdentificar.Identificado = true;
                            _verificarHuellaInfo.PersonaIdentificar.estado = dr.GetInt16(0);
                            _verificarHuellaInfo.PersonaIdentificar.municipio = dr.GetInt16(1);
                            _verificarHuellaInfo.PersonaIdentificar.cereso = dr.GetString(2);
                            _verificarHuellaInfo.PersonaIdentificar.ano = dr.GetInt16(3);
                            _verificarHuellaInfo.PersonaIdentificar.folio = dr.GetInt64(4);

                            await RegistrarMatch(_verificarHuellaInfo.PersonaIdentificar, 1, conn);

                            break;
                        }
                    }
                }
                return _verificarHuellaInfo;
            }
            catch (Exception ex)
            {
                Utils.LogEvent(ex.Message);
                throw;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            #endregion
        }

        public async Task<VerificarHuellaInfo> BuscarFacialEnTemplates(NSubject subjectBuscar, int idBusqueda)
        {
            #region BuscarHuellaEnTemplates
            var select = "SELECT ESTADO,MUNICIPIO,CERESO,ANO,FOLIO,FOTO_CENTRO FROM BTS.FICHA ";
            var conn = new OracleConnection(_connStr);
            var template = new byte[] { };
            var subject = new NSubject();
            var facial = new NFace();
            var _verificarHuellaInfo = new VerificarHuellaInfo();

            try
            {
                await conn.OpenAsync();

                var cmdSelect = new OracleCommand(select, conn);
                var dr = await cmdSelect.ExecuteReaderAsync();

                while (await dr.ReadAsync())
                {
                    if (dr.IsDBNull(5) == false)
                    {
                        template = (byte[])dr[5];

                        facial = new NFace();
                        facial.SampleBuffer = new Neurotec.IO.NBuffer(template);

                        subject = new NSubject();
                        subject.Faces.Add(facial);

                        var status = await _biometricClient.VerifyAsync(subject, subjectBuscar);

                        var verificationStatus = string.Format("Verification status: {0}", status);

                        if (status == NBiometricStatus.Ok)
                        {
                            _verificarHuellaInfo.Identificado = true;
                            _verificarHuellaInfo.PersonaIdentificar.id = idBusqueda;
                            _verificarHuellaInfo.PersonaIdentificar.Identificado = true;
                            _verificarHuellaInfo.PersonaIdentificar.estado = dr.GetInt16(0);
                            _verificarHuellaInfo.PersonaIdentificar.municipio = dr.GetInt16(1);
                            _verificarHuellaInfo.PersonaIdentificar.cereso = dr.GetString(2);
                            _verificarHuellaInfo.PersonaIdentificar.ano = dr.GetInt16(3);
                            _verificarHuellaInfo.PersonaIdentificar.folio = dr.GetInt64(4);

                            await RegistrarMatch(_verificarHuellaInfo.PersonaIdentificar, 1, conn);

                            break;
                        }
                    }
                }
                return _verificarHuellaInfo;
            }
            catch (Exception ex)
            {
                Utils.LogEvent(ex.Message);
                throw;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            #endregion
        }

        public async Task<VerificarHuellaInfo> BuscarVozEnTemplates(NSubject subjectBuscar, int idBusqueda)
        {
            #region BuscarHuellaEnTemplates
            var select = "SELECT ESTADO,MUNICIPIO,CERESO,ANO,FOLIO,NUM_INGRESO,ARCHIVO FROM BTS.FICHA_VOZ ";
            var conn = new OracleConnection(_connStr);
            var template = new byte[] { };
            var subject = new NSubject();
            var voice = new NVoice();
            var _verificarHuellaInfo = new VerificarHuellaInfo();

            try
            {
                await conn.OpenAsync();

                var cmdSelect = new OracleCommand(select, conn);
                var dr = await cmdSelect.ExecuteReaderAsync();

                while (await dr.ReadAsync())
                {
                    if (dr.IsDBNull(6) == false)
                    {
                        template = (byte[])dr[6];

                        voice = new NVoice();
                        voice.SampleBuffer = new Neurotec.IO.NBuffer(template);

                        subject = new NSubject();
                        subject.Voices.Add(voice);

                        var status = await _biometricClient.VerifyAsync(subject, subjectBuscar);

                        var verificationStatus = string.Format("Verification status: {0}", status);

                        if (status == NBiometricStatus.Ok)
                        {
                            _verificarHuellaInfo.Identificado = true;
                            _verificarHuellaInfo.PersonaIdentificar.id = idBusqueda;
                            _verificarHuellaInfo.PersonaIdentificar.Identificado = true;
                            _verificarHuellaInfo.PersonaIdentificar.estado = dr.GetInt16(0);
                            _verificarHuellaInfo.PersonaIdentificar.municipio = dr.GetInt16(1);
                            _verificarHuellaInfo.PersonaIdentificar.cereso = dr.GetString(2);
                            _verificarHuellaInfo.PersonaIdentificar.ano = dr.GetInt16(3);
                            _verificarHuellaInfo.PersonaIdentificar.folio = dr.GetInt64(4);
                            _verificarHuellaInfo.PersonaIdentificar.num_ingreso = dr.GetInt16(5);

                            await RegistrarMatch(_verificarHuellaInfo.PersonaIdentificar, 1, conn);

                            break;
                        }
                    }
                }
                return _verificarHuellaInfo;
            }
            catch (Exception ex)
            {
                Utils.LogEvent(ex.Message);
                throw;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            #endregion
        }

        public async Task<VerificarHuellaInfo> BuscarIrisEnTemplates(NSubject subjectBuscar, int idBusqueda, short ojo)
        {
            #region BuscarHuellaEnTemplates
            var select = "SELECT ESTADO,MUNICIPIO,CERESO,ANO,FOLIO,IRIS_IZQ FROM BTS.EXP_IRIS ";
            var conn = new OracleConnection(_connStr);
            var template = new byte[] { };
            var subject = new NSubject();
            var iris = new NIris();
            var _verificarHuellaInfo = new VerificarHuellaInfo();

            try
            {
                if (ojo == DERECHO)
                {
                    select = "SELECT ESTADO,MUNICIPIO,CERESO,ANO,FOLIO,IRIS_DER FROM BTS.EXP_IRIS ";
                }

                await conn.OpenAsync();

                var cmdSelect = new OracleCommand(select, conn);
                var dr = await cmdSelect.ExecuteReaderAsync();

                while (await dr.ReadAsync())
                {
                    if (dr.IsDBNull(5) == false)
                    {
                        template = (byte[])dr[5];

                        iris = new NIris();

                        try
                        {
                            iris.SampleBuffer = new Neurotec.IO.NBuffer(template);

                            subject = new NSubject();
                            subject.Irises.Add(iris);

                            var status = await _biometricClient.VerifyAsync(subject, subjectBuscar);

                            var verificationStatus = string.Format("Verification status: {0}", status);

                            if (status == NBiometricStatus.Ok)
                            {
                                _verificarHuellaInfo.Identificado = true;
                                _verificarHuellaInfo.PersonaIdentificar.id = idBusqueda;
                                _verificarHuellaInfo.PersonaIdentificar.Identificado = true;
                                _verificarHuellaInfo.PersonaIdentificar.estado = dr.GetInt16(0);
                                _verificarHuellaInfo.PersonaIdentificar.municipio = dr.GetInt16(1);
                                _verificarHuellaInfo.PersonaIdentificar.cereso = dr.GetString(2);
                                _verificarHuellaInfo.PersonaIdentificar.ano = dr.GetInt16(3);
                                _verificarHuellaInfo.PersonaIdentificar.folio = dr.GetInt64(4);

                                await RegistrarMatch(_verificarHuellaInfo.PersonaIdentificar, 1, conn);

                                break;
                            }
                        }
                        catch (Neurotec.NeurotecException exN)
                        {
                            Utils.LogEvent(exN);
                        }
                        catch (Exception ex)
                        {
                            Utils.LogEvent(ex);
                        }
                    }
                }
                return _verificarHuellaInfo;
            }
            catch (Exception ex)
            {
                Utils.LogEvent(ex);
                throw;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            #endregion
        }

        public async Task RegistrarMatch(PersonaInfo personaIdentificada, short consec, OracleConnection conn)
        {
            #region RegistrarDatos
            string insert = string.Format("INSERT INTO BTS.VALIDA_HUELLA " +
                                          "(ID,CONSEC,ESTADO,MUNICIPIO,CERESO,ANO,FOLIO)" +
                                          " VALUES ({0},{1},{2},{3},'{4}',{5},{6})",
                personaIdentificada.id,
                consec,
                personaIdentificada.estado,
                personaIdentificada.municipio,
                personaIdentificada.cereso,
                personaIdentificada.ano,
                personaIdentificada.folio);

            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    await conn.OpenAsync();

                OracleCommand cmdInsert = new OracleCommand(insert, conn);

                await cmdInsert.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            #endregion
        }

        public string ObtenerConexion()
        {
            #region Conexion
            var oracnsBuilder = new OracleConnectionStringBuilder();
            var connectionString = string.Empty;
            var appSettings = ConfigurationManager.AppSettings;

            oracnsBuilder.UserID = appSettings["SICEPUSUARIO"].ToUpper();
            oracnsBuilder.Password = appSettings["SICEPPASS"].ToUpper();
            oracnsBuilder.PersistSecurityInfo = false;
            oracnsBuilder.Pooling = false;
            oracnsBuilder.DataSource = appSettings["SICEPNODO"].ToUpper();

            connectionString = oracnsBuilder.ToString();

            return connectionString;
            #endregion
        }
    }
}