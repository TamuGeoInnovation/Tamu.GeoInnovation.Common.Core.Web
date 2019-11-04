using System;

namespace USC.GISResearchLab.Core.WebServices.ResultCodes
{

    public enum QueryStatusCodes
    {
        Unknown,
        Success,
        Failure,
        InternalError,
        APIKeyError,
        APIKeyMissing,
        APIKeyInvalid,
        APIKeyNotActivated,
        NonProfitError,
        NonProfitNotConfirmed,
        QueryError,
        QueryParameterMissing,
        QueryRestrictedCoverage,
        QuotaExceededError,
        QuotaExceededAnonymous,
        QuotaExceededPaid,
        VersionInvalid,
        VersionMissing,
        VersionOutdated
    };

    public class QueryResultCodeManager
    {

        // Unknown Error
        public const int STATUS_CODE_UNKNOWN_VALUE = 0;
        public const string STATUS_CODE_UNKNOWN_NAME = "Unknown";

        // Success 
        public const int STATUS_CODE_SUCCESS_VALUE = 200;
        public const string STATUS_CODE_SUCCESS_NAME = "Success";

        // Internal errors
        public const int STATUS_CODE_FAILURE_VALUE = 500;
        public const int STATUS_CODE_FAILURE_INTERNAL_VALUE = 501;

        public const string STATUS_CODE_FAILURE_NAME = "Failure";
        public const string STATUS_CODE_FAILURE_INTERNAL_NAME = "Internal Error";

        // API Key errors
        public const int STATUS_CODE_FAILURE_API_KEY_ERROR_VALUE = 400;
        public const int STATUS_CODE_FAILURE_API_KEY_MISSING_VALUE = 401;
        public const int STATUS_CODE_FAILURE_API_KEY_INVALID_VALUE = 402;
        public const int STATUS_CODE_FAILURE_API_KEY_NOT_ACTIVATED_VALUE = 403;

        public const string STATUS_CODE_FAILURE_API_KEY_ERROR_NAME = "API Key Error";
        public const string STATUS_CODE_FAILURE_API_KEY_MISSING_NAME = "API Key Missing";
        public const string STATUS_CODE_FAILURE_API_KEY_INVALID_NAME = "API Key Invalid";
        public const string STATUS_CODE_FAILURE_API_KEY_NOT_ACTIVATED_NAME = "API Key Not Activated";

        // Query parameter errors
        public const int STATUS_CODE_FAILURE_QUERY_ERROR_VALUE = 410;
        public const int STATUS_CODE_FAILURE_QUERY_PARAMETER_MISSING_VALUE = 411;
        public const int STATUS_CODE_FAILURE_QUERY_RESTRICTED_COVERAGE_VALUE = 412;

        public const string STATUS_CODE_FAILURE_QUERY_ERROR_NAME = "Query Error";
        public const string STATUS_CODE_FAILURE_QUERY_PARAMETER_MISSING_NAME = "Query Parameter Missing";
        public const string STATUS_CODE_FAILURE_QUERY_RESTRICTED_COVERAGE_NAME = "Query Restricted Coverage";

        // Non-profit errors
        public const int STATUS_CODE_FAILURE_NON_PROFIT_ERROR_VALUE = 450;
        public const int STATUS_CODE_FAILURE_NON_PROFIT_NOT_CONFIRMED_VALUE = 451;

        public const string STATUS_CODE_FAILURE_NON_PROFIT_ERROR_NAME = "Non Profit Error";
        public const string STATUS_CODE_FAILURE_NON_PROFIT_NOT_CONFIRMED_NAME = "Non Profit Not Confirmed";

        // Quota errors
        public const int STATUS_CODE_FAILURE_QUOTA_EXCEEDED_VALUE = 470;
        public const int STATUS_CODE_FAILURE_QUOTA_ANONYMOUS_EXCEEDED_VALUE = 471;
        public const int STATUS_CODE_FAILURE_QUOTA_PAID_EXCEEDED_VALUE = 472;

        public const string STATUS_CODE_FAILURE_QUOTA_EXCEEDED_NAME = "Quota Exceeded Error";
        public const string STATUS_CODE_FAILURE_QUOTA_ANONYMOUS_EXCEEDED_NAME = "Anonymous Quota Exceeded";
        public const string STATUS_CODE_FAILURE_QUOTA_PAID_EXCEEDED_NAME = "Paid Quota Exceeded";


        // Versions errors
        public const int STATUS_CODE_FAILURE_VERSION_MISSING_VALUE = 480;
        public const int STATUS_CODE_FAILURE_VERSION_INVALID_VALUE = 481;
        public const int STATUS_CODE_FAILURE_VERSION_OUTDATED_VALUE = 482;

        public const string STATUS_CODE_FAILURE_VERSION_MISSING_NAME = "Version Missing";
        public const string STATUS_CODE_FAILURE_VERSION_INVALID_NAME = "Version Invalid";
        public const string STATUS_CODE_FAILURE_VERSION_OUTDATED_NAME = "Version Outdated";


        public static string GetStatusCodeName(QueryStatusCodes code)
        {
            string ret = STATUS_CODE_UNKNOWN_NAME;
            switch (code)
            {
                case QueryStatusCodes.APIKeyError:
                    ret = STATUS_CODE_FAILURE_API_KEY_ERROR_NAME;
                    break;
                case QueryStatusCodes.APIKeyInvalid:
                    ret = STATUS_CODE_FAILURE_API_KEY_INVALID_NAME;
                    break;
                case QueryStatusCodes.APIKeyMissing:
                    ret = STATUS_CODE_FAILURE_API_KEY_MISSING_NAME;
                    break;
                case QueryStatusCodes.APIKeyNotActivated:
                    ret = STATUS_CODE_FAILURE_API_KEY_NOT_ACTIVATED_NAME;
                    break;
                case QueryStatusCodes.Failure:
                    ret = STATUS_CODE_FAILURE_NAME;
                    break;
                case QueryStatusCodes.InternalError:
                    ret = STATUS_CODE_FAILURE_INTERNAL_NAME;
                    break;
                case QueryStatusCodes.NonProfitError:
                    ret = STATUS_CODE_FAILURE_NON_PROFIT_ERROR_NAME;
                    break;
                case QueryStatusCodes.NonProfitNotConfirmed:
                    ret = STATUS_CODE_FAILURE_NON_PROFIT_NOT_CONFIRMED_NAME;
                    break;
                case QueryStatusCodes.QueryError:
                    ret = STATUS_CODE_FAILURE_QUERY_ERROR_NAME;
                    break;
                case QueryStatusCodes.QueryParameterMissing:
                    ret = STATUS_CODE_FAILURE_QUERY_PARAMETER_MISSING_NAME;
                    break;
                case QueryStatusCodes.QueryRestrictedCoverage:
                    ret = STATUS_CODE_FAILURE_QUERY_RESTRICTED_COVERAGE_NAME;
                    break;
                case QueryStatusCodes.QuotaExceededAnonymous:
                    ret = STATUS_CODE_FAILURE_QUOTA_ANONYMOUS_EXCEEDED_NAME;
                    break;
                case QueryStatusCodes.QuotaExceededError:
                    ret = STATUS_CODE_FAILURE_QUOTA_EXCEEDED_NAME;
                    break;
                case QueryStatusCodes.QuotaExceededPaid:
                    ret = STATUS_CODE_FAILURE_QUOTA_PAID_EXCEEDED_NAME;
                    break;
                case QueryStatusCodes.Success:
                    ret = STATUS_CODE_SUCCESS_NAME;
                    break;
                case QueryStatusCodes.Unknown:
                    ret = STATUS_CODE_UNKNOWN_NAME;
                    break;
                case QueryStatusCodes.VersionInvalid:
                    ret = STATUS_CODE_FAILURE_VERSION_INVALID_NAME;
                    break;
                case QueryStatusCodes.VersionMissing:
                    ret = STATUS_CODE_FAILURE_VERSION_MISSING_NAME;
                    break;
                case QueryStatusCodes.VersionOutdated:
                    ret = STATUS_CODE_FAILURE_VERSION_OUTDATED_NAME;
                    break;
                default:
                    throw new Exception("Unexpected QueryStatusCodes: " + code);
            }
            return ret;
        }

        public static QueryStatusCodes GetStatusCodeValueFromName(string statusName)
        {
            QueryStatusCodes ret = QueryStatusCodes.Unknown;
            if (String.Compare(statusName, STATUS_CODE_FAILURE_API_KEY_ERROR_NAME, true) == 0)
            {
                ret = QueryStatusCodes.APIKeyError;
            }
            else if (String.Compare(statusName, STATUS_CODE_FAILURE_API_KEY_INVALID_NAME, true) == 0)
            {
                ret = QueryStatusCodes.APIKeyInvalid;
            }
            else if (String.Compare(statusName, STATUS_CODE_FAILURE_API_KEY_MISSING_NAME, true) == 0)
            {
                ret = QueryStatusCodes.APIKeyMissing;
            }
            else if (String.Compare(statusName, STATUS_CODE_FAILURE_API_KEY_NOT_ACTIVATED_NAME, true) == 0)
            {
                ret = QueryStatusCodes.APIKeyNotActivated;
            }
            else if (String.Compare(statusName, STATUS_CODE_FAILURE_NAME, true) == 0)
            {
                ret = QueryStatusCodes.Failure;
            }
            else if (String.Compare(statusName, STATUS_CODE_FAILURE_INTERNAL_NAME, true) == 0)
            {
                ret = QueryStatusCodes.InternalError;
            }
            else if (String.Compare(statusName, STATUS_CODE_FAILURE_NON_PROFIT_ERROR_NAME, true) == 0)
            {
                ret = QueryStatusCodes.NonProfitError;
            }
            else if (String.Compare(statusName, STATUS_CODE_FAILURE_NON_PROFIT_NOT_CONFIRMED_NAME, true) == 0)
            {
                ret = QueryStatusCodes.NonProfitNotConfirmed;
            }
            else if (String.Compare(statusName, STATUS_CODE_FAILURE_QUERY_ERROR_NAME, true) == 0)
            {
                ret = QueryStatusCodes.QueryError;
            }
            else if (String.Compare(statusName, STATUS_CODE_FAILURE_QUERY_PARAMETER_MISSING_NAME, true) == 0)
            {
                ret = QueryStatusCodes.QueryParameterMissing;
            }
            else if (String.Compare(statusName, STATUS_CODE_FAILURE_QUERY_RESTRICTED_COVERAGE_NAME, true) == 0)
            {
                ret = QueryStatusCodes.QueryRestrictedCoverage;
            }
            else if (String.Compare(statusName, STATUS_CODE_FAILURE_QUOTA_ANONYMOUS_EXCEEDED_NAME, true) == 0)
            {
                ret = QueryStatusCodes.QuotaExceededAnonymous;
            }
            else if (String.Compare(statusName, STATUS_CODE_FAILURE_QUOTA_EXCEEDED_NAME, true) == 0)
            {
                ret = QueryStatusCodes.QuotaExceededError;
            }
            else if (String.Compare(statusName, STATUS_CODE_FAILURE_QUOTA_PAID_EXCEEDED_NAME, true) == 0)
            {
                ret = QueryStatusCodes.QuotaExceededPaid;
            }
            else if (String.Compare(statusName, STATUS_CODE_FAILURE_VERSION_INVALID_NAME, true) == 0)
            {
                ret = QueryStatusCodes.VersionInvalid;
            }
            else if (String.Compare(statusName, STATUS_CODE_FAILURE_VERSION_MISSING_NAME, true) == 0)
            {
                ret = QueryStatusCodes.VersionMissing;
            }
            else if (String.Compare(statusName, STATUS_CODE_FAILURE_VERSION_OUTDATED_NAME, true) == 0)
            {
                ret = QueryStatusCodes.VersionOutdated;
            }
            else if (String.Compare(statusName, STATUS_CODE_SUCCESS_NAME, true) == 0)
            {
                ret = QueryStatusCodes.Success;
            }
            else if (String.Compare(statusName, STATUS_CODE_UNKNOWN_NAME, true) == 0)
            {
                ret = QueryStatusCodes.Unknown;
            }
            else
            {
                throw new Exception("Unexpected StatusCodeName: " + statusName);
            }
            return ret;
        }

        public static int GetStatusCodeValue(QueryStatusCodes code)
        {
            int ret = STATUS_CODE_UNKNOWN_VALUE;
            switch (code)
            {
                case QueryStatusCodes.APIKeyError:
                    ret = STATUS_CODE_FAILURE_API_KEY_ERROR_VALUE;
                    break;
                case QueryStatusCodes.APIKeyInvalid:
                    ret = STATUS_CODE_FAILURE_API_KEY_INVALID_VALUE;
                    break;
                case QueryStatusCodes.APIKeyMissing:
                    ret = STATUS_CODE_FAILURE_API_KEY_MISSING_VALUE;
                    break;
                case QueryStatusCodes.APIKeyNotActivated:
                    ret = STATUS_CODE_FAILURE_API_KEY_NOT_ACTIVATED_VALUE;
                    break;
                case QueryStatusCodes.Failure:
                    ret = STATUS_CODE_FAILURE_VALUE;
                    break;
                case QueryStatusCodes.InternalError:
                    ret = STATUS_CODE_FAILURE_INTERNAL_VALUE;
                    break;
                case QueryStatusCodes.NonProfitError:
                    ret = STATUS_CODE_FAILURE_NON_PROFIT_ERROR_VALUE;
                    break;
                case QueryStatusCodes.NonProfitNotConfirmed:
                    ret = STATUS_CODE_FAILURE_NON_PROFIT_NOT_CONFIRMED_VALUE;
                    break;
                case QueryStatusCodes.QueryError:
                    ret = STATUS_CODE_FAILURE_QUERY_ERROR_VALUE;
                    break;
                case QueryStatusCodes.QueryParameterMissing:
                    ret = STATUS_CODE_FAILURE_QUERY_PARAMETER_MISSING_VALUE;
                    break;
                case QueryStatusCodes.QueryRestrictedCoverage:
                    ret = STATUS_CODE_FAILURE_QUERY_RESTRICTED_COVERAGE_VALUE;
                    break;
                case QueryStatusCodes.QuotaExceededAnonymous:
                    ret = STATUS_CODE_FAILURE_QUOTA_ANONYMOUS_EXCEEDED_VALUE;
                    break;
                case QueryStatusCodes.QuotaExceededError:
                    ret = STATUS_CODE_FAILURE_QUOTA_EXCEEDED_VALUE;
                    break;
                case QueryStatusCodes.QuotaExceededPaid:
                    ret = STATUS_CODE_FAILURE_QUOTA_PAID_EXCEEDED_VALUE;
                    break;
                case QueryStatusCodes.Success:
                    ret = STATUS_CODE_SUCCESS_VALUE;
                    break;
                case QueryStatusCodes.Unknown:
                    ret = STATUS_CODE_UNKNOWN_VALUE;
                    break;
                case QueryStatusCodes.VersionInvalid:
                    ret = STATUS_CODE_FAILURE_VERSION_INVALID_VALUE;
                    break;
                case QueryStatusCodes.VersionMissing:
                    ret = STATUS_CODE_FAILURE_VERSION_MISSING_VALUE;
                    break;
                case QueryStatusCodes.VersionOutdated:
                    ret = STATUS_CODE_FAILURE_VERSION_OUTDATED_VALUE;
                    break;
                default:
                    throw new Exception("Unexpected QueryStatusCodes: " + code);
            }
            return ret;
        }

        public static QueryStatusCodes GetStatusCodeFromValue(int value)
        {
            QueryStatusCodes ret = QueryStatusCodes.Unknown;
            switch (value)
            {
                case STATUS_CODE_FAILURE_API_KEY_ERROR_VALUE:
                    ret = QueryStatusCodes.APIKeyError;
                    break;
                case STATUS_CODE_FAILURE_API_KEY_INVALID_VALUE:
                    ret = QueryStatusCodes.APIKeyInvalid;
                    break;
                case STATUS_CODE_FAILURE_API_KEY_MISSING_VALUE:
                    ret = QueryStatusCodes.APIKeyMissing;
                    break;
                case STATUS_CODE_FAILURE_API_KEY_NOT_ACTIVATED_VALUE:
                    ret = QueryStatusCodes.APIKeyNotActivated;
                    break;
                case STATUS_CODE_FAILURE_VALUE:
                    ret = QueryStatusCodes.Failure;
                    break;
                case STATUS_CODE_FAILURE_INTERNAL_VALUE:
                    ret = QueryStatusCodes.InternalError;
                    break;
                case STATUS_CODE_FAILURE_NON_PROFIT_ERROR_VALUE:
                    ret = QueryStatusCodes.NonProfitError;
                    break;
                case STATUS_CODE_FAILURE_NON_PROFIT_NOT_CONFIRMED_VALUE:
                    ret = QueryStatusCodes.NonProfitNotConfirmed;
                    break;
                case STATUS_CODE_FAILURE_QUERY_ERROR_VALUE:
                    ret = QueryStatusCodes.QueryError;
                    break;
                case STATUS_CODE_FAILURE_QUERY_PARAMETER_MISSING_VALUE:
                    ret = QueryStatusCodes.QueryParameterMissing;
                    break;
                case STATUS_CODE_FAILURE_QUERY_RESTRICTED_COVERAGE_VALUE:
                    ret = QueryStatusCodes.QueryRestrictedCoverage;
                    break;
                case STATUS_CODE_FAILURE_QUOTA_ANONYMOUS_EXCEEDED_VALUE:
                    ret = QueryStatusCodes.QuotaExceededAnonymous;
                    break;
                case STATUS_CODE_FAILURE_QUOTA_EXCEEDED_VALUE:
                    ret = QueryStatusCodes.QuotaExceededError;
                    break;
                case STATUS_CODE_FAILURE_QUOTA_PAID_EXCEEDED_VALUE:
                    ret = QueryStatusCodes.QuotaExceededPaid;
                    break;
                case STATUS_CODE_SUCCESS_VALUE:
                    ret = QueryStatusCodes.Success;
                    break;
                case STATUS_CODE_UNKNOWN_VALUE:
                    ret = QueryStatusCodes.Unknown;
                    break;
                case STATUS_CODE_FAILURE_VERSION_INVALID_VALUE:
                    ret = QueryStatusCodes.VersionInvalid;
                    break;
                case STATUS_CODE_FAILURE_VERSION_MISSING_VALUE:
                    ret = QueryStatusCodes.VersionMissing;
                    break;
                case STATUS_CODE_FAILURE_VERSION_OUTDATED_VALUE:
                    ret = QueryStatusCodes.VersionOutdated;
                    break;
                default:
                    throw new Exception("Unexpected QueryStatusCodeValue: " + value);
            }
            return ret;
        }
    }
}
