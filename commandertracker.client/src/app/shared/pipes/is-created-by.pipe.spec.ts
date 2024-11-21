import { IsCreatedByPipe } from './is-created-by.pipe';

describe('IsCreatedByPipe', () => {
  it('create an instance', () => {
    const pipe = new IsCreatedByPipe();
    expect(pipe).toBeTruthy();
  });
});
