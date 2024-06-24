import { ToColorIdentityStringPipe } from './to-color-identity-string.pipe';

describe('ToColorIdentityStringPipe', () => {
  it('create an instance', () => {
    const pipe = new ToColorIdentityStringPipe();
    expect(pipe).toBeTruthy();
  });
});
