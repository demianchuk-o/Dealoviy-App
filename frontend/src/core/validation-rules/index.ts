const required = (value: string) => !!value || "This field is required";

const minLength = (min: number) => (value: string) =>
  value.length < min || `This field must be at least ${min} characters long`;

const maxLength = (max: number) => (value: string) =>
  value.length > max || `This field must be at most ${max} characters long`;

const password = (min: number, max: number) => {
  return (value: string) => {
    if (value.length < min || value.length > max)
      return `Password must be at most ${min} and at least ${max} characters long`;

    return true;
  };
};

const uaNumber = (value: string) => {
  if (!value.startsWith("380")) {
    return "Phone number must start with +380";
  } else if (value.length !== 12) {
    return "Phone number must be 12 characters long";
  }
  return true;
};

const tagContact = (value: string) =>
  value.startsWith("@") || "Tag must start with @";

const requiredIf = (
  condition: boolean | (() => boolean),
  rule: ((value: string) => boolean | string) | boolean | string
) =>
  (typeof condition === "function" ? condition() : condition) ? rule : true;

export {
  maxLength,
  minLength,
  password,
  required,
  requiredIf,
  tagContact,
  uaNumber,
};
