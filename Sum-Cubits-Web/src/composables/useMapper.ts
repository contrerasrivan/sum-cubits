  const mapTo = <T>(dto?: unknown): T => {
    const obj: T = {} as T
    // @ts-expect-error we don't have specific type to manage
    Object.keys(dto).map((key: string) => (obj[key] = dto[key]))
    return obj
  }
