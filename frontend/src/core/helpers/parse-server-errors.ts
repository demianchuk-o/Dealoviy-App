import { AxiosError } from "axios";

const parseServerErrors = (
  error: AxiosError<{
    errors: object;
  }>
) => {
  const errors = error.response?.data.errors;
  if (!errors) return "";
  const result = Object.entries(errors).map(([, value]) => value);
  return result.join(" ");
};

export default parseServerErrors;
